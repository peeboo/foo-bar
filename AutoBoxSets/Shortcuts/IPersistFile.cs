// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistFile.cs" company="">
//   
// </copyright>
// <summary>
//   The PersistFile interface.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Shortcuts
{

    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    /// <summary>The PersistFile interface.</summary>
    [Guid("0000010B-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport]
    public interface IPersistFile
    {
        /// <summary>The get class id.</summary>
        /// <param name="pClassID">The p class id.</param>
        void GetClassID(out Guid pClassID);


        /// <summary>The is dirty.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        int IsDirty();


        /// <summary>The load.</summary>
        /// <param name="pszFileName">The psz file name.</param>
        /// <param name="dwMode">The dw mode.</param>
        void Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, int dwMode);


        /// <summary>The save.</summary>
        /// <param name="pszFileName">The psz file name.</param>
        /// <param name="fRemember">The f remember.</param>
        void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);


        /// <summary>The save completed.</summary>
        /// <param name="pszFileName">The psz file name.</param>
        void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);


        /// <summary>The get cur file.</summary>
        /// <param name="ppszFileName">The ppsz file name.</param>
        void GetCurFile(out IntPtr ppszFileName);
    }

}
