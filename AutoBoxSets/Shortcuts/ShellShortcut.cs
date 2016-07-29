// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellShortcut.cs" company="">
//   
// </copyright>
// <summary>
//   The shell shortcut.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

// ReSharper disable IdentifierTypo

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
        /// <summary>The infotip size.</summary>
        private const int Infotipsize = 1024;

        /// <summary>The max path.</summary>
        private const int MaxPath = 260;

        /// <summary>The sw show maximized.</summary>
        private const int SwShowmaximized = 3;

        /// <summary>The sw show minimized.</summary>
        private const int SwShowminimized = 2;

        /// <summary>The sw show minno active.</summary>
        private const int SwShowminnoactive = 7;

        /// <summary>The sw show normal.</summary>
        private const int SwShownormal = 1;

        /// <summary>The ms path.</summary>
        private readonly string mSPath;

        /// <summary>The m link.</summary>
        private IShellLinkA mLink;


        /// <summary>Initializes a new instance of the <see cref="ShellShortcut"/> class.</summary>
        /// <param name="linkPath">The link path.</param>
        public ShellShortcut(string linkPath)
        {
            this.mSPath = linkPath;
            this.mLink = (IShellLinkA)new ShellLink();
            if (!File.Exists(linkPath))
            {
                return;
            }

            ((IPersistFile)this.mLink).Load(linkPath, 0);
        }


        /// <summary>Gets or sets the arguments.</summary>
        [NotNull]
        public string Arguments
        {
            get
            {
                var pszArgs = new StringBuilder(Infotipsize);
                this.mLink.GetArguments(pszArgs, pszArgs.Capacity);
                return pszArgs.ToString();
            }

            set
            {
                this.mLink.SetArguments(value);
            }
        }


        /// <summary>Gets or sets the description.</summary>
        [NotNull]
        public string Description
        {
            get
            {
                var pszName = new StringBuilder(Infotipsize);
                this.mLink.GetDescription(pszName, pszName.Capacity);
                return pszName.ToString();
            }

            set
            {
                this.mLink.SetDescription(value);
            }
        }


        /// <summary>Gets or sets the hotkey.</summary>
        /// <exception cref="ArgumentException">Hotkey must include a modifier key.</exception>
        public Keys Hotkey
        {
            get
            {
                short pwHotkey;
                this.mLink.GetHotkey(out pwHotkey);
                return (Keys)(((pwHotkey & 65280) << 8) | (pwHotkey & byte.MaxValue));
            }

            set
            {
                if ((value & Keys.Modifiers) == Keys.None)
                {
                    throw new ArgumentException("Hotkey must include a modifier key.");
                }

                this.mLink.SetHotkey((short)((Keys)((int)(value & Keys.Modifiers) >> 8) | (value & Keys.KeyCode)));
            }
        }


        /// <summary>Gets the icon.</summary>
        [CanBeNull]
        public Icon Icon
        {
            get
            {
                var pszIconPath = new StringBuilder(MaxPath);
                int piIcon;
                this.mLink.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
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
                var pszIconPath = new StringBuilder(MaxPath);
                int piIcon;
                this.mLink.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
                return piIcon;
            }

            set
            {
                this.mLink.SetIconLocation(this.IconPath, value);
            }
        }


        /// <summary>Gets or sets the icon path.</summary>
        [NotNull]
        public string IconPath
        {
            get
            {
                var pszIconPath = new StringBuilder(MaxPath);
                int piIcon;
                this.mLink.GetIconLocation(pszIconPath, pszIconPath.Capacity, out piIcon);
                return pszIconPath.ToString();
            }

            set
            {
                this.mLink.SetIconLocation(value, this.IconIndex);
            }
        }


        /// <summary>Gets or sets the path.</summary>
        [NotNull]
        public string Path
        {
            get
            {
                var pfd = new WIN32_FIND_DATAA();
                var pszFile = new StringBuilder(MaxPath);
                this.mLink.GetPath(pszFile, pszFile.Capacity, out pfd, SLGP_FLAGS.SLGP_UNCPRIORITY);
                return pszFile.ToString();
            }

            set
            {
                this.mLink.SetPath(value);
            }
        }


        /// <summary>Gets the shell link.</summary>
        public object ShellLink => this.mLink;


        /// <summary>Gets or sets the window style.</summary>
        /// <exception cref="ArgumentException">Unsupported ProcessWindowStyle value.</exception>
        public ProcessWindowStyle WindowStyle
        {
            get
            {
                int piShowCmd;
                this.mLink.GetShowCmd(out piShowCmd);
                switch (piShowCmd)
                {
                    case SwShowminimized:
                    case SwShowminnoactive:
                        return ProcessWindowStyle.Minimized;
                    case SwShowmaximized:
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
                        iShowCmd = SwShownormal;
                        break;
                    case ProcessWindowStyle.Minimized:
                        iShowCmd = SwShowminnoactive;
                        break;
                    case ProcessWindowStyle.Maximized:
                        iShowCmd = SwShowmaximized;
                        break;
                    default:
                        throw new ArgumentException("Unsupported ProcessWindowStyle value.");
                }

                this.mLink.SetShowCmd(iShowCmd);
            }
        }


        /// <summary>Gets or sets the working directory.</summary>
        [NotNull]
        public string WorkingDirectory
        {
            get
            {
                var pszDir = new StringBuilder(MaxPath);
                this.mLink.GetWorkingDirectory(pszDir, pszDir.Capacity);
                return pszDir.ToString();
            }

            set
            {
                this.mLink.SetWorkingDirectory(value);
            }
        }


        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            if (this.mLink == null)
            {
                return;
            }

            Marshal.ReleaseComObject(this.mLink);
            this.mLink = null;
        }


        /// <summary>The save.</summary>
        public void Save()
        {
            ((IPersistFile)this.mLink).Save(this.mSPath, true);
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
