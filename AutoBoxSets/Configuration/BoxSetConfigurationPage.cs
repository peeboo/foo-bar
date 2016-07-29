// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="BoxSetConfigurationPage.cs" company="">
//   
// </copyright>
// <summary>
//   The box set configuration page.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Configuration
{

    using System.IO;

    using JetBrains.Annotations;

    using MediaBrowser.Common.Plugins;
    using MediaBrowser.Controller.Plugins;


    /// <summary>The box set configuration page.</summary>
    [UsedImplicitly]
    internal class BoxSetConfigurationPage : IPluginConfigurationPage
    {
        /// <summary>Gets the configuration page type.</summary>
        public ConfigurationPageType ConfigurationPageType => ConfigurationPageType.PluginConfiguration;


        /// <summary>Gets the name.</summary>
        [NotNull]
        public string Name => "Automatic BoxSets";


        /// <summary>Gets the plugin.</summary>
        public IPlugin Plugin => (IPlugin)AutoBoxSets.Plugin.Instance;


        /// <summary>The get html stream.</summary>
        /// <returns>The <see cref="Stream"/>.</returns>
        [CanBeNull]
        public Stream GetHtmlStream()
        {
            return this.GetType().Assembly.GetManifestResourceStream("AutoBoxSets.Configuration.configPage.html");
        }
    }

}
