// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="SLR_FLAGS.cs" company="">
//   
// </copyright>
// <summary>
//   The sl r_ flags.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Shortcuts
{

    using System;


    /// <summary>The sl r_ flags.</summary>
    [Flags]
    public enum SLR_FLAGS
    {
        /// <summary>The sl r_ n o_ ui.</summary>
        SLR_NO_UI = 1, 

        /// <summary>The sl r_ an y_ match.</summary>
        SLR_ANY_MATCH = 2, 

        /// <summary>The sl r_ update.</summary>
        SLR_UPDATE = 4, 

        /// <summary>The sl r_ noupdate.</summary>
        SLR_NOUPDATE = 8, 

        /// <summary>The sl r_ nosearch.</summary>
        SLR_NOSEARCH = 16, 

        /// <summary>The sl r_ notrack.</summary>
        SLR_NOTRACK = 32, 

        /// <summary>The sl r_ nolinkinfo.</summary>
        SLR_NOLINKINFO = 64, 

        /// <summary>The sl r_ invok e_ msi.</summary>
        SLR_INVOKE_MSI = 128, 
    }

}
