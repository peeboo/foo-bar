// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="SLGP_FLAGS.cs" company="">
// </copyright>
// <summary>
//   The slg p_ flags.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace AutoBoxSets.Shortcuts
{

    using System;


    /// <summary>The slg p_ flags.</summary>
    [Flags]
    public enum SLGP_FLAGS
    {
        /// <summary>The slg p_ shortpath.</summary>
        SLGP_SHORTPATH = 1, 

        /// <summary>The slg p_ uncpriority.</summary>
        SLGP_UNCPRIORITY = 2, 

        /// <summary>The slg p_ rawpath.</summary>
        SLGP_RAWPATH = 4, 
    }

}
