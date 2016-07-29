// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="Plugin.cs" company="emby">
//   2016
// </copyright>
// <summary>
//   
// </summary>
// ------------------------------------------------------------------------------------------------------------------------


namespace AutoBoxSets
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoBoxSets.Configuration;
    using AutoBoxSets.Utility;

    using JetBrains.Annotations;

    using MediaBrowser.Common.Configuration;
    using MediaBrowser.Common.Plugins;
    using MediaBrowser.Controller.Collections;
    using MediaBrowser.Controller.Entities;
    using MediaBrowser.Controller.Entities.Movies;
    using MediaBrowser.Controller.Library;
    using MediaBrowser.Controller.Providers;
    using MediaBrowser.Model.Entities;
    using MediaBrowser.Model.Logging;
    using MediaBrowser.Model.Plugins;
    using MediaBrowser.Model.Serialization;


    /// <summary>The plugin.</summary>
    public class Plugin : BasePlugin<PluginConfiguration>
    {
        /// <summary>The box set tag.</summary>
        public const string BoxSetTag = " [MB Auto Set]";

        /// <summary>The scan task running.</summary>
        public static bool ScanTaskRunning;

        /// <summary>The library manager.</summary>
        [NotNull]
        private readonly ILibraryManager libraryManager;

        /// <summary>The scan lock.</summary>
        private readonly object scanLock = new object();


        /// <summary>Initializes a new instance of the <see cref="Plugin"/> class.</summary>
        /// <param name="applicationPaths">The application paths.</param>
        /// <param name="xmlSerializer">The xml serializer.</param>
        /// <param name="libraryManager">The library manager.</param>
        public Plugin(
            [NotNull] IApplicationPaths applicationPaths,
            [NotNull] IXmlSerializer xmlSerializer,
            [NotNull] ILibraryManager libraryManager)
            : base(applicationPaths, xmlSerializer)
        {
            this.libraryManager = libraryManager;
            Instance = this;
        }


        /// <summary>Gets the instance.</summary>
        [NotNull]
        public static Plugin Instance { get; private set; }


        /// <summary>Gets or sets the logger.</summary>
        public static ILogger Logger { get; set; }


        /// <summary>Gets or sets the registration.</summary>
        public static MBRegistrationRecord Registration { get; set; }


        /// <summary>Gets the description.</summary>
        [NotNull]
        public override string Description => "Automatic BoxSets for your collection.";


        /// <summary>Gets the name.</summary>
        [NotNull]
        public override string Name => "Auto Box Sets";


        /// <summary>The create all box sets.</summary>
        /// <param name="progress">The progress.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="System.Threading.CancellationTokenSource"/> has
        ///     been disposed.
        /// </exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type TResult.</exception>
        public async Task CreateAllBoxSetsAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            lock (this.scanLock)
            {
                if (ScanTaskRunning)
                {
                    return;
                }

                ScanTaskRunning = true;
            }

            var potentialCollections =
                this.GetAllItems(typeof(Movie))
                    .Where(i => (i.GetProviderId(MetadataProviders.TmdbCollection) != null) && !(i.Parent is BoxSet))
                    .GroupBy(i => i.GetProviderId(MetadataProviders.TmdbCollection))
                    .ToList();

            var total = potentialCollections.Count;
            var current = 1.0;

            Logger.Info("Executing Automatic BoxSet creation.  Found {0} potential box sets.", total);

            foreach (var collection in potentialCollections)
            {
                var num = await this.UpdateBoxSetAsync(collection).ConfigureAwait(false) ? 1 : 0;
                progress.Report(current++ / total);

                cancellationToken.ThrowIfCancellationRequested();
            }

            Logger.Info("Automatic BoxSet creation completed.");
            ScanTaskRunning = false;
        }


        /// <summary>The update box set.</summary>
        /// <param name="collection">The collection.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type TResult.</exception>
        public async Task<bool> UpdateBoxSetAsync([NotNull] IGrouping<string, BaseItem> collection)
        {
            var realCount = collection.DistinctBy(i => i.GetProviderId(MetadataProviders.Tmdb)).Count();

            Logger.Debug("Found box set {0} with {1} members.", collection.Key, realCount);

            ServerEntryPoint.Instance.IgnoreCollectionEvents = true;

            var changed = false;

            var set =
                this.GetAllItems(typeof(BoxSet))
                    .Cast<BoxSet>()
                    .FirstOrDefault(b => b.GetProviderId(MetadataProviders.Tmdb) == collection.Key);

            var exists = set != null;

            if (realCount >= this.Configuration.MinimumMembers)
            {
                if (!exists)
                {
                    try
                    {
                        var providerManager = ServerEntryPoint.Instance.ProviderManager;
                        var remoteSearchQuery = new RemoteSearchQuery<BoxSetInfo>
                            {
                                SearchInfo =
                                    new BoxSetInfo
                                        {
                                            ProviderIds =
                                                new Dictionary<string, string> { { MetadataProviders.Tmdb.ToString(), collection.Key } }
                                        }
                            };

                        var results =
                            await
                            providerManager.GetRemoteSearchResults<BoxSet, BoxSetInfo>(remoteSearchQuery, CancellationToken.None)
                                           .ConfigureAwait(false);

                        var result = results.FirstOrDefault();
                        if (result != null)
                        {
                            Logger.Info("Verified set {0} as {1} - creating...", collection.Key, result.Name);

                            set =
                                await
                                ServerEntryPoint.Instance.CollectionManager.CreateCollection(
                                    new CollectionCreationOptions
                                        {
                                            Name = result.Name,
                                            ProviderIds =
                                                new Dictionary<string, string>
                                                    {
                                                        { MetadataProviders.Tmdb.ToString(), collection.Key }
                                                    },
                                            ItemIdList = collection.Select(i => i.Id).ToList()
                                        }).ConfigureAwait(false);

                            var boxsets = Instance.Configuration.BoxsetPaths.ToList();
                            boxsets.Add(ServerEntryPoint.Instance.NormalizeBoxSetPath(set.Path));
                            Instance.Configuration.BoxsetPaths = boxsets.ToArray();
                            Instance.SaveConfiguration();
                        }
                        else
                        {
                            Logger.Info(
                                "Unable to verify collection ID of {0} which is referenced in {1} - not creating set.",
                                collection.Key,
                                collection.First().Name ?? collection.First().Path ?? "<Unknown>");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Logger.ErrorException(
                            "Possible Invalid Tmdb collection Id: {0} in {1}",
                            ex,
                            collection.Key,
                            collection.First().Name ?? collection.First().Path ?? "<Unknown>");
                    }

                    changed = true;
                }
                else
                {
                    Logger.Debug("Box set already exists. Will confirm members.");
                    var currentChildren = set.LinkedChildren.ToList();

                    foreach (var baseItem in collection)
                    {
                        var member = baseItem;
                        var existing = currentChildren.FirstOrDefault(
                            s =>
                                {
                                    var itemId = s.ItemId;
                                    var id = member.Id;
                                    return itemId.HasValue && (itemId.GetValueOrDefault() == id);
                                });

                        if (existing != null)
                        {
                            Logger.Debug("Member {0} already exists", member.Name);
                            currentChildren.Remove(existing);
                        }
                        else
                        {
                            Logger.Debug("Adding member {0}", member.Name);
                            try
                            {
                                await
                                    ServerEntryPoint.Instance.CollectionManager.AddToCollection(set.Id, new[] { member.Id })
                                                    .ConfigureAwait(false);

                                changed = true;
                            }
                            catch (Exception ex)
                            {
                                Logger.ErrorException("Error adding box set member {0}", ex, member.Name ?? "<Unknown>");
                            }
                        }
                    }
                }
            }
            else
            {
                Logger.Debug(
                    "Ignoring set because only has {0} member (needs at least {1}).",
                    collection.Count(),
                    Instance.Configuration.MinimumMembers);
            }

            this.Configuration.NeedsUpdate = false;
            this.SaveConfiguration();
            ServerEntryPoint.Instance.IgnoreCollectionEvents = false;

            return changed;
        }


        /// <summary>The update configuration.</summary>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        /// <exception cref="AggregateException">
        ///     At least one of the <see cref="System.Threading.Tasks.Task"/> instances was
        ///     canceled. If a task was canceled, the <see cref="T:System.AggregateException"/> exception contains an
        ///     <see cref="System.OperationCanceledException"/> exception in its
        ///     <see cref="System.AggregateException.InnerExceptions"/> collection.-or- An exception was thrown during the
        ///     execution of at least one of the <see cref="System.Threading.Tasks.Task"/> instances.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     One or more of the <see cref="System.Threading.Tasks.Task"/> objects in tasks
        ///     has been disposed.
        /// </exception>
        public override void UpdateConfiguration([NotNull] BasePluginConfiguration configuration)
        {
            base.UpdateConfiguration(configuration);

            var task =
                Task.Factory.StartNew(
                    async () =>
                    await
                    ServerEntryPoint.OnConfigurationUpdatedAsync(this.Configuration, (PluginConfiguration)configuration)
                                    .ConfigureAwait(false));

            Task.WaitAll(task);
        }


        /// <summary>The get all items.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        private IEnumerable<BaseItem> GetAllItems([NotNull] Type type)
        {
            return this.libraryManager.GetItemList(new InternalItemsQuery { IncludeItemTypes = new[] { type.Name } });
        }
    }

}
