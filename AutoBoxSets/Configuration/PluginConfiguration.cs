// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="PluginConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The plugin configuration.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Configuration
{

    using JetBrains.Annotations;

    using MediaBrowser.Model.Plugins;


    /// <summary>The plugin configuration.</summary>
    [UsedImplicitly]
    public class PluginConfiguration : BasePluginConfiguration
    {
        /// <summary>Initializes a new instance of the <see cref="PluginConfiguration"/> class.</summary>
        public PluginConfiguration()
        {
            this.MinimumMembers = 2;
            this.NeedsUpdate = true;
            this.BoxsetPaths = new string[0];
        }


        /// <summary>Gets or sets the boxset paths.</summary>
        public string[] BoxsetPaths { get; set; }


        /// <summary>Gets or sets the minimum members.</summary>
        public int MinimumMembers { get; set; }


        /// <summary>Gets or sets a value indicating whether needs update.</summary>
        public bool NeedsUpdate { get; set; }
    }

}
