// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEntryPoint.cs" company="">
//   
// </copyright>
// <summary>
//   The server entry point.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets
{

    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoBoxSets.Configuration;

    using CommonIO;

    using JetBrains.Annotations;

    using MediaBrowser.Common.Configuration;
    using MediaBrowser.Common.ScheduledTasks;
    using MediaBrowser.Common.Security;
    using MediaBrowser.Controller.Collections;
    using MediaBrowser.Controller.Library;
    using MediaBrowser.Controller.Plugins;
    using MediaBrowser.Controller.Providers;
    using MediaBrowser.Model.Extensions;
    using MediaBrowser.Model.Logging;


    /// <summary>The server entry point.</summary>
    [UsedImplicitly]
    public class ServerEntryPoint : IServerEntryPoint, IDisposable, IRequiresRegistration
    {
        /// <summary>The timer lock.</summary>
        private readonly object timerLock = new object();

        /// <summary>The update timer.</summary>
        private Timer updateTimer;


        /// <summary>Initializes a new instance of the <see cref="ServerEntryPoint"/> class. </summary>
        /// <param name="taskManager">The task Manager.</param>
        /// <param name="libraryManager">The library Manager.</param>
        /// <param name="fileSystem">The file System.</param>
        /// <param name="providerManager">The provider Manager.</param>
        /// <param name="logManager">The log Manager.</param>
        /// <param name="securityManager">The security Manager.</param>
        /// <param name="libraryMonitor">The library Monitor.</param>
        /// <param name="collectionManager">The collection Manager.</param>
        /// <param name="applicationPaths">The application Paths.</param>
        public ServerEntryPoint(
            [NotNull] ITaskManager taskManager, 
            [NotNull] ILibraryManager libraryManager, 
            [NotNull] IFileSystem fileSystem, 
            [NotNull] IProviderManager providerManager, 
            [NotNull] ILogManager logManager, 
            [NotNull] ISecurityManager securityManager, 
            [NotNull] ILibraryMonitor libraryMonitor, 
            [NotNull] ICollectionManager collectionManager, 
            [NotNull] IApplicationPaths applicationPaths)
        {
            this.TaskManager = taskManager;
            this.LibraryManager = libraryManager;
            this.FileSystem = fileSystem;
            this.LibraryMonitor = libraryMonitor;
            this.PluginSecurityManager = securityManager;
            this.CollectionManager = collectionManager;
            this.ApplicationPaths = applicationPaths;
            this.ProviderManager = providerManager;
            Plugin.Logger = logManager.GetLogger(Plugin.Instance.Name);
            Instance = this;
        }


        /// <summary>Gets the instance.</summary>
        public static ServerEntryPoint Instance { get; private set; }


        /// <summary>Gets the collection manager.</summary>
        public ICollectionManager CollectionManager { get; private set; }


        /// <summary>Gets the file system.</summary>
        public IFileSystem FileSystem { get; private set; }


        /// <summary>Gets or sets a value indicating whether ignore collection events.</summary>
        public bool IgnoreCollectionEvents { get; set; }


        /// <summary>Gets the library manager.</summary>
        public ILibraryManager LibraryManager { get; private set; }


        /// <summary>Gets the library monitor.</summary>
        public ILibraryMonitor LibraryMonitor { get; private set; }


        /// <summary>Gets the provider manager.</summary>
        public IProviderManager ProviderManager { get; private set; }


        /// <summary>Gets or sets the task manager.</summary>
        public ITaskManager TaskManager { get; set; }


        /// <summary>Gets or sets the application paths.</summary>
        private IApplicationPaths ApplicationPaths { get; set; }


        /// <summary>Gets or sets the plugin security manager.</summary>
        private ISecurityManager PluginSecurityManager { get; set; }


        /// <summary>The on configuration updated.</summary>
        /// <param name="oldConfig">The old config.</param>
        /// <param name="newConfig">The new config.</param>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="ObjectDisposedException">The associated <see cref="System.Threading.CancellationTokenSource"/> has
        ///     been disposed.</exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type TResult.</exception>
        public static async Task OnConfigurationUpdatedAsync(
            [NotNull] PluginConfiguration oldConfig, 
            [NotNull] PluginConfiguration newConfig)
        {
            if (oldConfig.MinimumMembers == newConfig.MinimumMembers)
            {
                return;
            }

            await Plugin.Instance.CreateAllBoxSetsAsync(new Progress<double>(), CancellationToken.None).ConfigureAwait(false);
        }


        /// <summary>The dispose.</summary>
        public void Dispose()
        {
        }


        /// <summary>The load registration info async.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task LoadRegistrationInfoAsync()
        {
            Plugin.Registration = await this.PluginSecurityManager.GetRegistrationStatus(nameof(AutoBoxSets), null).ConfigureAwait(false);
        }


        /// <summary>The normalize box set path.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string NormalizeBoxSetPath(string path)
        {
            return path.Replace(this.ApplicationPaths.ProgramDataPath, string.Empty, StringComparison.OrdinalIgnoreCase);
        }


        /// <summary>The run.</summary>
        /// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type TResult.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="System.Threading.CancellationTokenSource"/> has
        ///     been disposed.
        /// </exception>
        public void Run()
        {
            if (!Plugin.Instance.Configuration.NeedsUpdate)
            {
                return;
            }

            Plugin.Instance.CreateAllBoxSetsAsync(new Progress<double>(), CancellationToken.None).ConfigureAwait(false);
        }


        /// <summary>The is auto box set.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsAutoBoxSet([NotNull] string path)
        {
            if (path.Contains(" [MB Auto Set]"))
            {
                return true;
            }

            return Plugin.Instance.Configuration.BoxsetPaths.Contains(this.NormalizeBoxSetPath(path), StringComparer.OrdinalIgnoreCase);
        }
    }

}
