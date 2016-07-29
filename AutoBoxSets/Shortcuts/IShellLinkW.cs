// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="IShellLinkW.cs" company="">
//   
// </copyright>
// <summary>
//   The ShellLinkW interface.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Shortcuts
{

    using System;
    using System.Runtime.InteropServices;
    using System.Text;


    /// <summary>The ShellLinkW interface.</summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F9-0000-0000-C000-000000000046"), ComImport]
    public interface IShellLinkW
    {
        /// <summary>The get path.</summary>
        /// <param name="pszFile">The psz file.</param>
        /// <param name="cchMaxPath">The cch max path.</param>
        /// <param name="pfd">The pfd.</param>
        /// <param name="fFlags">The f flags.</param>
        void GetPath(
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszFile, 
            int cchMaxPath, 
            out WIN32_FIND_DATAW pfd, 
            SLGP_FLAGS fFlags);


        /// <summary>The get id list.</summary>
        /// <param name="ppidl">The ppidl.</param>
        void GetIDList(out IntPtr ppidl);


        /// <summary>The set id list.</summary>
        /// <param name="pidl">The pidl.</param>
        void SetIDList(IntPtr pidl);


        /// <summary>The get description.</summary>
        /// <param name="pszName">The psz name.</param>
        /// <param name="cchMaxName">The cch max name.</param>
        void GetDescription([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszName, int cchMaxName);


        /// <summary>The set description.</summary>
        /// <param name="pszName">The psz name.</param>
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);


        /// <summary>The get working directory.</summary>
        /// <param name="pszDir">The psz dir.</param>
        /// <param name="cchMaxPath">The cch max path.</param>
        void GetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszDir, int cchMaxPath);


        /// <summary>The set working directory.</summary>
        /// <param name="pszDir">The psz dir.</param>
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);


        /// <summary>The get arguments.</summary>
        /// <param name="pszArgs">The psz args.</param>
        /// <param name="cchMaxPath">The cch max path.</param>
        void GetArguments([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszArgs, int cchMaxPath);


        /// <summary>The set arguments.</summary>
        /// <param name="pszArgs">The psz args.</param>
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);


        /// <summary>The get hotkey.</summary>
        /// <param name="pwHotkey">The pw hotkey.</param>
        void GetHotkey(out short pwHotkey);


        /// <summary>The set hotkey.</summary>
        /// <param name="wHotkey">The w hotkey.</param>
        void SetHotkey(short wHotkey);


        /// <summary>The get show cmd.</summary>
        /// <param name="piShowCmd">The pi show cmd.</param>
        void GetShowCmd(out int piShowCmd);


        /// <summary>The set show cmd.</summary>
        /// <param name="iShowCmd">The i show cmd.</param>
        void SetShowCmd(int iShowCmd);


        /// <summary>The get icon location.</summary>
        /// <param name="pszIconPath">The psz icon path.</param>
        /// <param name="cchIconPath">The cch icon path.</param>
        /// <param name="piIcon">The pi icon.</param>
        void GetIconLocation([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszIconPath, int cchIconPath, out int piIcon);


        /// <summary>The set icon location.</summary>
        /// <param name="pszIconPath">The psz icon path.</param>
        /// <param name="iIcon">The i icon.</param>
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);


        /// <summary>The set relative path.</summary>
        /// <param name="pszPathRel">The psz path rel.</param>
        /// <param name="dwReserved">The dw reserved.</param>
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);


        /// <summary>The resolve.</summary>
        /// <param name="hwnd">The hwnd.</param>
        /// <param name="fFlags">The f flags.</param>
        void Resolve(IntPtr hwnd, SLR_FLAGS fFlags);


        /// <summary>The set path.</summary>
        /// <param name="pszFile">The psz file.</param>
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

}
