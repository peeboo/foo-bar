// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="WIN32_FIND_DATAA.cs" company="">
// </copyright>
// <summary>
//   The wi n 32_ fin d_ dataa.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace AutoBoxSets.Shortcuts
{

    using System.Runtime.InteropServices;

    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;


    /// <summary>The wi n 32_ fin d_ dataa.</summary>
    public struct WIN32_FIND_DATAA
    {
        /// <summary>The ma x_ path.</summary>
        private const int MAX_PATH = 260;

        /// <summary>The dw file attributes.</summary>
        public int dwFileAttributes;

        /// <summary>The ft creation time.</summary>
        public FILETIME ftCreationTime;

        /// <summary>The ft last access time.</summary>
        public FILETIME ftLastAccessTime;

        /// <summary>The ft last write time.</summary>
        public FILETIME ftLastWriteTime;

        /// <summary>The n file size high.</summary>
        public int nFileSizeHigh;

        /// <summary>The n file size low.</summary>
        public int nFileSizeLow;

        /// <summary>The dw reserved 0.</summary>
        public int dwReserved0;

        /// <summary>The dw reserved 1.</summary>
        public int dwReserved1;

        /// <summary>The c file name.</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;

        /// <summary>The c alternate file name.</summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    }

}
