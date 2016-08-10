// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="Version.cs" company="">
//   
// </copyright>
// <summary>
//   Supports all classes in the .NET Framework class hierarchy and provides low-level services to derived classes.
//   This is the ultimate base class of all classes in the .NET Framework; it is the root of the type hierarchy.To
//   browse the .NET Framework source code for this type, see the Reference Source.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Build.Extras
{

    using System;
    using System.Text.RegularExpressions;

    using JetBrains.Annotations;


    /// <summary>
    ///     Supports all classes in the .NET Framework class hierarchy and provides low-level services to derived classes.
    ///     This is the ultimate base class of all classes in the .NET Framework; it is the root of the type hierarchy.To
    ///     browse the .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    internal class Version
    {
        /// <summary>The build number.</summary>
        private string buildNumber;

        /// <summary>The major version.</summary>
        private string majorVersion;

        /// <summary>The minor version.</summary>
        private string minorVersion;

        /// <summary>The revision.</summary>
        private string revision;

        /// <summary>The version string.</summary>
        private string versionString;


        /// <summary>Initializes a new instance of the <see cref="Version"/> class. </summary>
        public Version()
        {
            this.MajorVersion = "1";
            this.MinorVersion = "0";
            this.BuildNumber = "0";
            this.Revision = "0";
        }


        /// <summary>Initializes a new instance of the <see cref="Version"/> class.</summary>
        /// <param name="version">The version.</param>
        public Version([NotNull] string version)
        {
            this.ParseVersion(version);
        }


        /// <summary>Gets or sets the build number.</summary>
        public string BuildNumber
        {
            get
            {
                return this.buildNumber;
            }

            set
            {
                this.buildNumber = value;
            }
        }


        /// <summary>Gets or sets the major version.</summary>
        public string MajorVersion
        {
            get
            {
                return this.majorVersion;
            }

            set
            {
                this.majorVersion = value;
            }
        }


        /// <summary>Gets or sets the minor version.</summary>
        public string MinorVersion
        {
            get
            {
                return this.minorVersion;
            }

            set
            {
                this.minorVersion = value;
            }
        }


        /// <summary>Gets or sets the revision.</summary>
        public string Revision
        {
            get
            {
                return this.revision;
            }

            set
            {
                this.revision = value;
            }
        }


        /// <summary>Gets or sets the version string.</summary>
        public string VersionString
        {
            get
            {
                return this.versionString;
            }

            set
            {
                this.ParseVersion(value);
            }
        }


        /// <summary>The to string.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0}.{1}.{2}.{3}", 
                (object)this.MajorVersion, 
                (object)this.MinorVersion, 
                (object)this.BuildNumber, 
                (object)this.Revision);
        }


        /// <summary>The parse version.</summary>
        /// <param name="version">The version.</param>
        /// <exception cref="ArgumentException"></exception>
        private void ParseVersion([NotNull] string version)
        {
            var matchCollection =
                new Regex(
                    "(?<majorVersion>(\\d+|\\*))\\.(?<minorVersion>(\\d+|\\*))\\.(?<buildNumber>(\\d+|\\*))\\.(?<revision>(\\d+|\\*))", 
                    RegexOptions.Compiled).Matches(version);
            if (matchCollection.Count != 1)
            {
                throw new ArgumentException("version", "The specified string is not a valid version number");
            }

            this.MajorVersion = matchCollection[0].Groups["majorVersion"].Value;
            this.MinorVersion = matchCollection[0].Groups["minorVersion"].Value;
            this.BuildNumber = matchCollection[0].Groups["buildNumber"].Value;
            this.Revision = matchCollection[0].Groups["revision"].Value;
            this.versionString = version;
        }
    }

}
