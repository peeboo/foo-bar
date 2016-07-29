// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellShortcut.cs" company="">
//   
// </copyright>
// <summary>
//   The shell shortcut.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace AutoBoxSets.Shortcuts
{

    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    using JetBrains.Annotations;


    /// <summary>The shell shortcut.</summary>
    public class ShellShortcut : IDisposable
    {
        /// <summary>The infotipsize.</summary>
        private const int INFOTIPSIZE = 1024;

        /// <summary>The ma x_ path.</summary>
        private const int MAX_PATH = 260;

        /// <summary>The s w_ showmaximized.</summary>
        private const int SW_SHOWMAXIMIZED = 3;

        /// <summary>The s w_ showminimized.</summary>
        private const int SW_SHOWMINIMIZED = 2;

        /// <summary>The s w_ showminnoactive.</summary>
        private const int SW_SHOWMINNOACTIVE = 7;

        /// <summary>The s w_ shownormal.</summary>
        private const int SW_SHOWNORMAL = 1;

        /// <summary>The m_ link.</summary>
        private IShellLinkA m_Link;

        /// <summary>The m_s path.</summary>
        private string m_sPath;


        /// <summary>Initializes a new instance of the <see cref="ShellShortcut"/> class.</summary>
        /// <param name="linkPath">The link path.</param>
        public ShellShortcut(string linkPath)
        {
            this.m_sPath = linkPath;
            this.m_Link = (IShellLinkA)new ShellLink();
            if (!File.Exists(linkPath))
            {
                return;
            }

            ((IPersistFile)this.m_Link).Load(linkPath, 0);
        }


        /// <summary>Gets or sets the arguments.</summary>
        [NotNull]
        public string Arguments
        {
            get
            {
                var pszArgs = new StringBuilder(1024);
                this.m_Link.GetArguments(pszArgs, pszArgs.Capacity);
                return pszArgs.ToString();
            }

            set
            {
                this.m_Link.SetArguments(value);
            }
        }


        /// <summary>Gets or sets the description.</summary>
        [NotNull]
        public string Description
        {
            get
            {
                var pszName = new StringBuilder(1024);
                this.m_Link.GetDescription(pszName, pszName.Capacity);
                return pszName.ToString();
            }

            set
            {
                this.m_Link.SetDescription(value);
            }
        }


        /// <summary>Gets or sets the hotkey.</summary>
        /// <exception cref="ArgumentException"></exception>
        public Keys Hotkey
        {
            get
            {
                short pwHotkey;
                this.m_Link.GetHotkey(out pwHotkey);
                return (Keys)(((pwHotkey & 65280) << 8) | (pwHotkey & byte.MaxValue));
            }

            set
            {
                if ((value & Keys.Modifiers) == Keys.None)
                {
                    throw new ArgumentException("Hotkey must include a modifier key.");
                }

                this.m_Link.SetHotkey((short)((Keys)((int)(value & Keys.Modifiers) >> 8) | (value & Keys.KeyCode)));
            }
        }


        /// <summary>Gets the icon.</summary>
        [CanBeNull]
        public Icon Icon
        {
            get
            {
                var pszIconPath = new StringBuilder(260);
                int piIcon;
                this.m_Link.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
                var icon1 = Native.ExtractIcon(Marshal.GetHINSTANCE(this.GetType().Module), pszIconPath.ToString(), piIcon);
                if (icon1 == IntPtr.Zero)
                {
                    return null;
                }

                var icon2 = Icon.FromHandle(icon1);
                var icon3 = (Icon)icon2.Clone();
                icon2.Dispose();
                Native.DestroyIcon(icon1);
                return icon3;
            }
        }


        /// <summary>Gets or sets the icon index.</summary>
        public int IconIndex
        {
            get
            {
                var pszIconPath = new StringBuilder(260);
                int piIcon;
                this.m_Link.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
                return piIcon;
            }

            set
            {
                this.m_Link.SetIconLocation(this.IconPath, value);
            }
        }


        /// <summary>Gets or sets the icon path.</summary>
        [NotNull]
        public string IconPath
        {
            get
            {
                var pszIconPath = new StringBuilder(260);
                int piIcon;
                this.m_Link.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
                return pszIconPath.ToString();
            }

            set
            {
                this.m_Link.SetIconLocation(value, this.IconIndex);
            }
        }


        /// <summary>Gets or sets the path.</summary>
        [NotNull]
        public string Path
        {
            get
            {
                var pfd = new WIN32_FIND_DATAA();
                var pszFile = new StringBuilder(260);
                this.m_Link.GetPath(pszFile, pszFile.Capacity, out pfd, SLGP_FLAGS.SLGP_UNCPRIORITY);
                return pszFile.ToString();
            }

            set
            {
                this.m_Link.SetPath(value);
            }
        }


        /// <summary>Gets the shell link.</summary>
        public object ShellLink
        {
            get
            {
                return this.m_Link;
            }
        }


        /// <summary>Gets or sets the window style.</summary>
        /// <exception cref="ArgumentException"></exception>
        public ProcessWindowStyle WindowStyle
        {
            get
            {
                int piShowCmd;
                this.m_Link.GetShowCmd(out piShowCmd);
                switch (piShowCmd)
                {
                    case 2:
                    case 7:
                        return ProcessWindowStyle.Minimized;
                    case 3:
                        return ProcessWindowStyle.Maximized;
                    default:
                        return ProcessWindowStyle.Normal;
                }
            }

            set
            {
                int iShowCmd;
                switch (value)
                {
                    case ProcessWindowStyle.Normal:
                        iShowCmd = 1;
                        break;
                    case ProcessWindowStyle.Minimized:
                        iShowCmd = 7;
                        break;
                    case ProcessWindowStyle.Maximized:
                        iShowCmd = 3;
                        break;
                    default:
                        throw new ArgumentException("Unsupported ProcessWindowStyle value.");
                }

                this.m_Link.SetShowCmd(iShowCmd);
            }
        }


        /// <summary>Gets or sets the working directory.</summary>
        [NotNull]
        public string WorkingDirectory
        {
            get
            {
                var pszDir = new StringBuilder(260);
                this.m_Link.GetWorkingDirectory(pszDir, pszDir.Capacity);
                return pszDir.ToString();
            }

            set
            {
                this.m_Link.SetWorkingDirectory(value);
            }
        }


        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            if (this.m_Link == null)
            {
                return;
            }

            Marshal.ReleaseComObject(this.m_Link);
            this.m_Link = null;
        }


        /// <summary>The save.</summary>
        public void Save()
        {
            ((IPersistFile)this.m_Link).Save(this.m_sPath, true);
        }


        /// <summary>The native.</summary>
        private class Native
        {
            /// <summary>The destroy icon.</summary>
            /// <param name="hIcon">The h icon.</param>
            /// <returns>The <see cref="bool"/>.</returns>
            [DllImport("user32.dll")]
            public static extern bool DestroyIcon(IntPtr hIcon);


            /// <summary>The extract icon.</summary>
            /// <param name="hInst">The h inst.</param>
            /// <param name="lpszExeFileName">The lpsz exe file name.</param>
            /// <param name="nIconIndex">The n icon index.</param>
            /// <returns>The <see cref="IntPtr"/>.</returns>
            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);
        }
    }

}
