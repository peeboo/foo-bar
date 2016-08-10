// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoTask.cs" company="">
//   
// </copyright>
// <summary>
//   The assembly info.
// </summary>
// ------------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Build.Extras
{

    using System;
    using System.IO;

    using JetBrains.Annotations;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;


    /// <summary>The assembly info.</summary>
    public class AssemblyInfo : Task
    {
        /// <summary>The assembly company.</summary>
        private string assemblyCompany;

        /// <summary>The assembly configuration.</summary>
        private string assemblyConfiguration;

        /// <summary>The assembly copyright.</summary>
        private string assemblyCopyright;

        /// <summary>The assembly culture.</summary>
        private string assemblyCulture;

        /// <summary>The assembly delay sign.</summary>
        private string assemblyDelaySign;

        /// <summary>The assembly description.</summary>
        private string assemblyDescription;

        /// <summary>The assembly file version settings.</summary>
        private AssemblyVersionSettings assemblyFileVersionSettings;

        /// <summary>The assembly guid.</summary>
        private string assemblyGuid;

        /// <summary>The assembly include signing information.</summary>
        private bool assemblyIncludeSigningInformation;

        /// <summary>The assembly info files.</summary>
        private ITaskItem[] assemblyInfoFiles;

        /// <summary>The assembly key file.</summary>
        private string assemblyKeyFile;

        /// <summary>The assembly key name.</summary>
        private string assemblyKeyName;

        /// <summary>The assembly product.</summary>
        private string assemblyProduct;

        /// <summary>The assembly title.</summary>
        private string assemblyTitle;

        /// <summary>The assembly trademark.</summary>
        private string assemblyTrademark;

        /// <summary>The assembly version settings.</summary>
        private AssemblyVersionSettings assemblyVersionSettings;

        /// <summary>The com visible.</summary>
        private string comVisible;

        /// <summary>The max assembly file version.</summary>
        private string maxAssemblyFileVersion;

        /// <summary>The max assembly version.</summary>
        private string maxAssemblyVersion;

        /// <summary>The raw assembly build number type.</summary>
        private string rawAssemblyBuildNumberType;

        /// <summary>The raw assembly file build number type.</summary>
        private string rawAssemblyFileBuildNumberType;

        /// <summary>The raw assembly file revision type.</summary>
        private string rawAssemblyFileRevisionType;

        /// <summary>The raw assembly revision type.</summary>
        private string rawAssemblyRevisionType;


        /// <summary>Gets or sets the assembly build number.</summary>
        public string AssemblyBuildNumber
        {
            get
            {
                return this.assemblyVersionSettings.BuildNumber;
            }

            set
            {
                this.assemblyVersionSettings.BuildNumber = value;
            }
        }


        /// <summary>Gets or sets the assembly build number format.</summary>
        public string AssemblyBuildNumberFormat
        {
            get
            {
                return this.assemblyVersionSettings.BuildNumberFormat;
            }

            set
            {
                this.assemblyVersionSettings.BuildNumberFormat = value;
            }
        }


        /// <summary>Gets or sets the assembly build number type.</summary>
        public string AssemblyBuildNumberType
        {
            get
            {
                return this.rawAssemblyBuildNumberType;
            }

            set
            {
                this.rawAssemblyBuildNumberType = value;
            }
        }


        /// <summary>Gets or sets the assembly company.</summary>
        public string AssemblyCompany
        {
            get
            {
                return this.assemblyCompany;
            }

            set
            {
                this.assemblyCompany = value;
            }
        }


        /// <summary>Gets or sets the assembly configuration.</summary>
        public string AssemblyConfiguration
        {
            get
            {
                return this.assemblyConfiguration;
            }

            set
            {
                this.assemblyConfiguration = value;
            }
        }


        /// <summary>Gets or sets the assembly copyright.</summary>
        public string AssemblyCopyright
        {
            get
            {
                return this.assemblyCopyright;
            }

            set
            {
                this.assemblyCopyright = value;
            }
        }


        /// <summary>Gets or sets the assembly culture.</summary>
        public string AssemblyCulture
        {
            get
            {
                return this.assemblyCulture;
            }

            set
            {
                this.assemblyCulture = value;
            }
        }


        /// <summary>Gets or sets the assembly delay sign.</summary>
        public string AssemblyDelaySign
        {
            get
            {
                return this.assemblyDelaySign;
            }

            set
            {
                this.assemblyDelaySign = value;
            }
        }


        /// <summary>Gets or sets the assembly description.</summary>
        public string AssemblyDescription
        {
            get
            {
                return this.assemblyDescription;
            }

            set
            {
                this.assemblyDescription = value;
            }
        }


        /// <summary>Gets or sets the assembly file build number.</summary>
        public string AssemblyFileBuildNumber
        {
            get
            {
                return this.assemblyFileVersionSettings.BuildNumber;
            }

            set
            {
                this.assemblyFileVersionSettings.BuildNumber = value;
            }
        }


        /// <summary>Gets or sets the assembly file build number format.</summary>
        public string AssemblyFileBuildNumberFormat
        {
            get
            {
                return this.assemblyFileVersionSettings.BuildNumberFormat;
            }

            set
            {
                this.assemblyFileVersionSettings.BuildNumberFormat = value;
            }
        }


        /// <summary>Gets or sets the assembly file build number type.</summary>
        public string AssemblyFileBuildNumberType
        {
            get
            {
                return this.rawAssemblyFileBuildNumberType;
            }

            set
            {
                this.rawAssemblyFileBuildNumberType = value;
            }
        }


        /// <summary>Gets or sets the assembly file major version.</summary>
        public string AssemblyFileMajorVersion
        {
            get
            {
                return this.assemblyFileVersionSettings.MajorVersion;
            }

            set
            {
                this.assemblyFileVersionSettings.MajorVersion = value;
            }
        }


        /// <summary>Gets or sets the assembly file minor version.</summary>
        public string AssemblyFileMinorVersion
        {
            get
            {
                return this.assemblyFileVersionSettings.MinorVersion;
            }

            set
            {
                this.assemblyFileVersionSettings.MinorVersion = value;
            }
        }


        /// <summary>Gets or sets the assembly file revision.</summary>
        public string AssemblyFileRevision
        {
            get
            {
                return this.assemblyFileVersionSettings.Revision;
            }

            set
            {
                this.assemblyFileVersionSettings.Revision = value;
            }
        }


        /// <summary>Gets or sets the assembly file revision format.</summary>
        public string AssemblyFileRevisionFormat
        {
            get
            {
                return this.assemblyFileVersionSettings.RevisionFormat;
            }

            set
            {
                this.assemblyFileVersionSettings.RevisionFormat = value;
            }
        }


        /// <summary>Gets or sets the assembly file revision type.</summary>
        public string AssemblyFileRevisionType
        {
            get
            {
                return this.rawAssemblyFileRevisionType;
            }

            set
            {
                this.rawAssemblyFileRevisionType = value;
            }
        }


        /// <summary>Gets or sets the assembly file version.</summary>
        public string AssemblyFileVersion
        {
            get
            {
                return this.assemblyFileVersionSettings.Version;
            }

            set
            {
                this.assemblyFileVersionSettings.Version = value;
            }
        }


        /// <summary>Gets or sets the assembly guid.</summary>
        public string AssemblyGuid
        {
            get
            {
                return this.assemblyGuid;
            }

            set
            {
                this.assemblyGuid = value;
            }
        }


        /// <summary>Gets or sets a value indicating whether assembly include signing information.</summary>
        public bool AssemblyIncludeSigningInformation
        {
            get
            {
                return this.assemblyIncludeSigningInformation;
            }

            set
            {
                this.assemblyIncludeSigningInformation = value;
            }
        }


        /// <summary>Gets or sets the assembly info files.</summary>
        [Required]
        public ITaskItem[] AssemblyInfoFiles
        {
            get
            {
                return this.assemblyInfoFiles;
            }

            set
            {
                this.assemblyInfoFiles = value;
            }
        }


        /// <summary>Gets or sets the assembly key file.</summary>
        public string AssemblyKeyFile
        {
            get
            {
                return this.assemblyKeyFile;
            }

            set
            {
                this.assemblyKeyFile = value;
            }
        }


        /// <summary>Gets or sets the assembly key name.</summary>
        public string AssemblyKeyName
        {
            get
            {
                return this.assemblyKeyName;
            }

            set
            {
                this.assemblyKeyName = value;
            }
        }


        /// <summary>Gets or sets the assembly major version.</summary>
        public string AssemblyMajorVersion
        {
            get
            {
                return this.assemblyVersionSettings.MajorVersion;
            }

            set
            {
                this.assemblyVersionSettings.MajorVersion = value;
            }
        }


        /// <summary>Gets or sets the assembly minor version.</summary>
        public string AssemblyMinorVersion
        {
            get
            {
                return this.assemblyVersionSettings.MinorVersion;
            }

            set
            {
                this.assemblyVersionSettings.MinorVersion = value;
            }
        }


        /// <summary>Gets or sets the assembly product.</summary>
        public string AssemblyProduct
        {
            get
            {
                return this.assemblyProduct;
            }

            set
            {
                this.assemblyProduct = value;
            }
        }


        /// <summary>Gets or sets the assembly revision.</summary>
        public string AssemblyRevision
        {
            get
            {
                return this.assemblyVersionSettings.Revision;
            }

            set
            {
                this.assemblyVersionSettings.Revision = value;
            }
        }


        /// <summary>Gets or sets the assembly revision format.</summary>
        public string AssemblyRevisionFormat
        {
            get
            {
                return this.assemblyVersionSettings.RevisionFormat;
            }

            set
            {
                this.assemblyVersionSettings.RevisionFormat = value;
            }
        }


        /// <summary>Gets or sets the assembly revision type.</summary>
        public string AssemblyRevisionType
        {
            get
            {
                return this.rawAssemblyRevisionType;
            }

            set
            {
                this.rawAssemblyRevisionType = value;
            }
        }


        /// <summary>Gets or sets the assembly title.</summary>
        public string AssemblyTitle
        {
            get
            {
                return this.assemblyTitle;
            }

            set
            {
                this.assemblyTitle = value;
            }
        }


        /// <summary>Gets or sets the assembly trademark.</summary>
        public string AssemblyTrademark
        {
            get
            {
                return this.assemblyTrademark;
            }

            set
            {
                this.assemblyTrademark = value;
            }
        }


        /// <summary>Gets or sets the assembly version.</summary>
        public string AssemblyVersion
        {
            get
            {
                return this.assemblyVersionSettings.Version;
            }

            set
            {
                this.assemblyVersionSettings.Version = value;
            }
        }


        /// <summary>Gets or sets the com visible.</summary>
        public string ComVisible
        {
            get
            {
                return this.comVisible;
            }

            set
            {
                this.comVisible = value;
            }
        }


        /// <summary>Gets or sets the max assembly file version.</summary>
        [Output]
        public string MaxAssemblyFileVersion
        {
            get
            {
                return this.maxAssemblyFileVersion;
            }

            set
            {
                this.maxAssemblyFileVersion = value;
            }
        }


        /// <summary>Gets or sets the max assembly version.</summary>
        [Output]
        public string MaxAssemblyVersion
        {
            get
            {
                return this.maxAssemblyVersion;
            }

            set
            {
                this.maxAssemblyVersion = value;
            }
        }


        /// <summary>The execute.</summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Execute()
        {
            var fileInfo = (FileInfo)null;
            var streamWriter = (StreamWriter)null;
            if (!this.ParseIncrementProperties() || !this.ValidateIncrementProperties())
            {
                return false;
            }

            this.MaxAssemblyVersion = "0.0.0.0";
            this.MaxAssemblyFileVersion = "0.0.0.0";
            foreach (var assemblyInfoFile in this.AssemblyInfoFiles)
            {
                var assemblyInfo = new AssemblyInfoWrapper(assemblyInfoFile.ItemSpec);
                if (!this.ValidateFileEntries(assemblyInfo, assemblyInfoFile.ItemSpec))
                {
                    return false;
                }

                this.Log.LogMessage(MessageImportance.Low, "Updating assembly info for {0}", (object)assemblyInfoFile.ItemSpec);
                var versionToUpdate1 = new Version(assemblyInfo["AssemblyVersion"]);
                this.UpdateAssemblyVersion(ref versionToUpdate1, this.assemblyVersionSettings);
                assemblyInfo["AssemblyVersion"] = versionToUpdate1.ToString();
                this.UpdateMaxVersion(ref this.maxAssemblyVersion, assemblyInfo["AssemblyVersion"]);
                var versionToUpdate2 = new Version(assemblyInfo["AssemblyFileVersion"]);
                this.UpdateAssemblyVersion(ref versionToUpdate2, this.assemblyFileVersionSettings);
                assemblyInfo["AssemblyFileVersion"] = versionToUpdate2.ToString();
                this.UpdateMaxVersion(ref this.maxAssemblyFileVersion, assemblyInfo["AssemblyFileVersion"]);
                this.UpdateProperty(assemblyInfo, "AssemblyTitle");
                this.UpdateProperty(assemblyInfo, "AssemblyDescription");
                this.UpdateProperty(assemblyInfo, "AssemblyConfiguration");
                this.UpdateProperty(assemblyInfo, "AssemblyCompany");
                this.UpdateProperty(assemblyInfo, "AssemblyProduct");
                this.UpdateProperty(assemblyInfo, "AssemblyCopyright");
                this.UpdateProperty(assemblyInfo, "AssemblyTrademark");
                this.UpdateProperty(assemblyInfo, "AssemblyCulture");
                this.UpdateProperty(assemblyInfo, "AssemblyGuid");
                if (this.AssemblyIncludeSigningInformation)
                {
                    this.UpdateProperty(assemblyInfo, "AssemblyKeyName");
                    this.UpdateProperty(assemblyInfo, "AssemblyKeyFile");
                    this.UpdateProperty(assemblyInfo, "AssemblyDelaySign");
                }

                this.UpdateProperty(assemblyInfo, "ComVisible");
                try
                {
                    fileInfo = this.GetTemporaryFileInfo();
                    streamWriter = new StreamWriter((Stream)fileInfo.OpenWrite());
                    assemblyInfo.Write(streamWriter);
                    streamWriter.Close();
                    File.Copy(fileInfo.FullName, assemblyInfoFile.ItemSpec, true);
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Close();
                    }

                    if (fileInfo != null)
                    {
                        fileInfo.Delete();
                    }
                }
            }

            return true;
        }


        /// <summary>The get temporary file info.</summary>
        /// <returns>The <see cref="FileInfo"/>.</returns>
        [CanBeNull]
        private FileInfo GetTemporaryFileInfo()
        {
            FileInfo fileInfo;
            try
            {
                fileInfo = new FileInfo(Path.GetTempFileName());
                fileInfo.Attributes = FileAttributes.Temporary;
            }
            catch (Exception ex)
            {
                this.Log.LogError("Unable to create temporary file: {0}", (object)ex.Message);
                return (FileInfo)null;
            }

            return fileInfo;
        }


        /// <summary>The parse increment properties.</summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ParseIncrementProperties()
        {
            var str = string.Join(", ", Enum.GetNames(typeof(IncrementMethod)));
            if (this.AssemblyBuildNumberType == null)
            {
                this.assemblyVersionSettings.BuildNumberType = IncrementMethod.NoIncrement;
            }
            else
            {
                if (!Enum.IsDefined(typeof(IncrementMethod), (object)this.AssemblyBuildNumberType))
                {
                    this.Log.LogError(
                        "The value specified for AssemblyBuildNumberType is invalid. It must be one of: {0}", 
                        (object)str);
                    return false;
                }

                this.assemblyVersionSettings.BuildNumberType =
                    (IncrementMethod)Enum.Parse(typeof(IncrementMethod), this.AssemblyBuildNumberType);
            }

            if (this.AssemblyRevisionType == null)
            {
                this.assemblyVersionSettings.RevisionType = IncrementMethod.NoIncrement;
            }
            else
            {
                if (!Enum.IsDefined(typeof(IncrementMethod), (object)this.AssemblyRevisionType))
                {
                    this.Log.LogError(
                        "The value specified for AssemblyRevisionType is invalid. It must be one of: {0}", 
                        (object)str);
                    return false;
                }

                this.assemblyVersionSettings.RevisionType =
                    (IncrementMethod)Enum.Parse(typeof(IncrementMethod), this.AssemblyRevisionType);
            }

            if (this.AssemblyFileBuildNumberType == null)
            {
                this.assemblyFileVersionSettings.BuildNumberType = IncrementMethod.NoIncrement;
            }
            else
            {
                if (!Enum.IsDefined(typeof(IncrementMethod), (object)this.AssemblyFileBuildNumberType))
                {
                    this.Log.LogError(
                        "The value specified for AssemblyFileBuildNumberType is invalid. It must be one of: {0}", 
                        (object)str);
                    return false;
                }

                this.assemblyFileVersionSettings.BuildNumberType =
                    (IncrementMethod)Enum.Parse(typeof(IncrementMethod), this.AssemblyFileBuildNumberType);
            }

            if (this.AssemblyFileRevisionType == null)
            {
                this.assemblyFileVersionSettings.RevisionType = IncrementMethod.NoIncrement;
            }
            else
            {
                if (!Enum.IsDefined(typeof(IncrementMethod), (object)this.AssemblyFileRevisionType))
                {
                    this.Log.LogError(
                        "The value specified for AssemblyFileRevisionType is invalid. It must be one of: {0}", 
                        (object)str);
                    return false;
                }

                this.assemblyFileVersionSettings.RevisionType =
                    (IncrementMethod)Enum.Parse(typeof(IncrementMethod), this.AssemblyFileRevisionType);
            }

            return true;
        }


        /// <summary>The update assembly version.</summary>
        /// <param name="versionToUpdate">The version to update.</param>
        /// <param name="requestedVersion">The requested version.</param>
        private void UpdateAssemblyVersion(ref Version versionToUpdate, AssemblyVersionSettings requestedVersion)
        {
            if (requestedVersion.Version != null)
            {
                this.Log.LogMessage(MessageImportance.Low, "\tUpdating assembly version to {0}", (object)requestedVersion.Version);
                versionToUpdate.VersionString = requestedVersion.Version;
            }

            if (requestedVersion.MajorVersion != null)
            {
                this.Log.LogMessage(
                    MessageImportance.Low, 
                    "\tUpdating major version to {0}", 
                    (object)requestedVersion.MajorVersion);
                versionToUpdate.MajorVersion = requestedVersion.MajorVersion;
            }

            if (requestedVersion.MinorVersion != null)
            {
                this.Log.LogMessage(
                    MessageImportance.Low, 
                    "\tUpdating minor version to {0}", 
                    (object)requestedVersion.MinorVersion);
                versionToUpdate.MinorVersion = requestedVersion.MinorVersion;
            }

            var str = string.Empty;
            var flag = (requestedVersion.BuildNumberType == IncrementMethod.DateString)
                       && (requestedVersion.RevisionType == IncrementMethod.AutoIncrement);
            if (flag)
            {
                str = versionToUpdate.BuildNumber;
            }

            versionToUpdate.BuildNumber = this.UpdateVersionProperty(
                versionToUpdate.BuildNumber, 
                requestedVersion.BuildNumberType, 
                requestedVersion.BuildNumber, 
                requestedVersion.BuildNumberFormat, 
                "\tUpdating build number to {0}");
            if (flag && (str != versionToUpdate.BuildNumber))
            {
                versionToUpdate.Revision = "-1";
            }

            versionToUpdate.Revision = this.UpdateVersionProperty(
                versionToUpdate.Revision, 
                requestedVersion.RevisionType, 
                requestedVersion.Revision, 
                requestedVersion.RevisionFormat, 
                "\tUpdating revision number to {0}");
            this.Log.LogMessage(MessageImportance.Low, "\tFinal assembly version is {0}", (object)versionToUpdate.ToString());
        }


        /// <summary>The update max version.</summary>
        /// <param name="maxVersion">The max version.</param>
        /// <param name="newVersion">The new version.</param>
        private void UpdateMaxVersion(ref string maxVersion, [CanBeNull] string newVersion)
        {
            if (newVersion == null)
            {
                return;
            }

            var version = new System.Version(maxVersion);
            if (!(new System.Version(newVersion) > version))
            {
                return;
            }

            maxVersion = newVersion;
        }


        /// <summary>The update property.</summary>
        /// <param name="assemblyInfo">The assembly info.</param>
        /// <param name="propertyName">The property name.</param>
        private void UpdateProperty(AssemblyInfoWrapper assemblyInfo, [NotNull] string propertyName)
        {
            var str = (string)this.GetType().GetProperty(propertyName).GetValue((object)this, (object[])null);
            if (str == null)
            {
                return;
            }

            assemblyInfo[propertyName] = str;
            this.Log.LogMessage(MessageImportance.Low, "\tUpdating {0} to \"{1}\"", (object)propertyName, (object)str);
        }


        /// <summary>The update version property.</summary>
        /// <param name="versionNumber">The version number.</param>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="logMessage">The log message.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string UpdateVersionProperty(
            string versionNumber, 
            IncrementMethod method, 
            string value, 
            string format, 
            string logMessage)
        {
            this.Log.LogMessage(MessageImportance.Low, "\tUpdate method is {0}", (object)method.ToString());
            if (format == string.Empty)
            {
                format = "0";
            }

            switch (method)
            {
                case IncrementMethod.NoIncrement:
                {
                    if (value == null)
                    {
                        return versionNumber;
                    }

                    this.Log.LogMessage(MessageImportance.Low, logMessage, (object)value);
                    return value;
                }

                case IncrementMethod.AutoIncrement:
                {
                    var num = int.Parse(versionNumber) + 1;
                    this.Log.LogMessage(MessageImportance.Low, logMessage, (object)num.ToString(format));
                    return num.ToString(format);
                }

                case IncrementMethod.DateString:
                {
                    var @string = DateTime.Now.ToString(format);
                    this.Log.LogMessage(MessageImportance.Low, logMessage, (object)@string);
                    return @string;
                }

                default:
                {
                    return string.Empty;
                }
            }
        }


        /// <summary>The validate file entries.</summary>
        /// <param name="assemblyInfo">The assembly info.</param>
        /// <param name="filename">The filename.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ValidateFileEntries(AssemblyInfoWrapper assemblyInfo, string filename)
        {
            if (((this.AssemblyBuildNumber != null) || (this.AssemblyRevision != null)
                 || ((this.AssemblyMajorVersion != null) || (this.AssemblyMinorVersion != null)))
                && (assemblyInfo["AssemblyVersion"] == null))
            {
                this.Log.LogError(
                    "Unable to update the AssemblyVersion for {0}: No stub entry for AssemblyVersion was found in the AssemblyInfo file.", 
                    (object)filename);
                return false;
            }

            if (((this.AssemblyFileBuildNumber != null) || (this.AssemblyFileRevision != null)
                 || ((this.AssemblyFileMajorVersion != null) || (this.AssemblyFileMinorVersion != null)))
                && (assemblyInfo["AssemblyFileVersion"] == null))
            {
                this.Log.LogError(
                    "Unable to update the AssemblyFileVersion for {0}: No stub entry for AssemblyFileVersion was found in the AssemblyInfo file.", 
                    (object)filename);
                return false;
            }

            return this.ValidateFileEntry(this.AssemblyCompany, assemblyInfo, "AssemblyCompany", filename)
                   && this.ValidateFileEntry(this.AssemblyConfiguration, assemblyInfo, "AssemblyConfiguration", filename)
                   && (this.ValidateFileEntry(this.AssemblyCopyright, assemblyInfo, "AssemblyCopyright", filename)
                       && this.ValidateFileEntry(this.AssemblyCulture, assemblyInfo, "AssemblyCulture", filename))
                   && (this.ValidateFileEntry(this.AssemblyDescription, assemblyInfo, "AssemblyDescription", filename)
                       && this.ValidateFileEntry(this.AssemblyProduct, assemblyInfo, "AssemblyProduct", filename)
                       && (this.ValidateFileEntry(this.AssemblyTitle, assemblyInfo, "AssemblyTitle", filename)
                           && this.ValidateFileEntry(this.AssemblyTrademark, assemblyInfo, "AssemblyTrademark", filename)))
                   && (!this.AssemblyIncludeSigningInformation
                       || (this.ValidateFileEntry(this.AssemblyDelaySign, assemblyInfo, "AssemblyDelaySign", filename)
                           && this.ValidateFileEntry(this.AssemblyKeyFile, assemblyInfo, "AssemblyKeyFile", filename)
                           && this.ValidateFileEntry(this.AssemblyKeyName, assemblyInfo, "AssemblyKeyName", filename)));
        }


        /// <summary>The validate file entry.</summary>
        /// <param name="taskAttributeValue">The task attribute value.</param>
        /// <param name="assemblyInfo">The assembly info.</param>
        /// <param name="fileAttribute">The file attribute.</param>
        /// <param name="filename">The filename.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ValidateFileEntry(
            [CanBeNull] string taskAttributeValue, 
            AssemblyInfoWrapper assemblyInfo, 
            string fileAttribute, 
            string filename)
        {
            if ((taskAttributeValue == null) || (assemblyInfo[fileAttribute] != null))
            {
                return true;
            }

            this.Log.LogError(
                "Unable to update the {0} for {1}: No stub entry for {0} was found in the AssemblyInfo file.", 
                (object)fileAttribute, 
                (object)filename);
            return false;
        }


        /// <summary>The validate increment properties.</summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ValidateIncrementProperties()
        {
            if ((this.assemblyVersionSettings.BuildNumberType == IncrementMethod.DateString)
                && (this.assemblyVersionSettings.BuildNumberFormat == null))
            {
                this.Log.LogError(
                    "The version increment method for AssemblyBuildNumber was set to DateString, but AssemblyBuildNumberFormat was not specified. Both properties must be set to use a date string as a build number.");
                return false;
            }

            if ((this.assemblyVersionSettings.RevisionType == IncrementMethod.DateString)
                && (this.assemblyVersionSettings.RevisionFormat == null))
            {
                this.Log.LogError(
                    "The version increment method for AssemblyRevision was set to DateString, but AssemblyRevisionFormat was not specified. Both properties must be set to use a date string as a revision.");
                return false;
            }

            if ((this.assemblyFileVersionSettings.BuildNumberType == IncrementMethod.DateString)
                && (this.AssemblyFileBuildNumberFormat == null))
            {
                this.Log.LogError(
                    "The version increment method for AssemblyFileBuildNumber was set to DateString, but AssemblyFileBuildNumberFormat was not specified. Both properties must be set to use a date string as a build number.");
                return false;
            }

            if ((this.assemblyFileVersionSettings.RevisionType != IncrementMethod.DateString)
                || (this.AssemblyFileRevisionFormat != null))
            {
                return true;
            }

            this.Log.LogError(
                "The version increment method for AssemblyFileRevision was set to DateString, but AssemblyFileRevisionFormat was not specified. Both properties must be set to use a date string as a revision.");
            return false;
        }


        /// <summary>The assembly version settings.</summary>
        private struct AssemblyVersionSettings
        {
            /// <summary>The major version.</summary>
            public string MajorVersion;

            /// <summary>The minor version.</summary>
            public string MinorVersion;

            /// <summary>The build number.</summary>
            public string BuildNumber;

            /// <summary>The revision.</summary>
            public string Revision;

            /// <summary>The version.</summary>
            public string Version;

            /// <summary>The build number type.</summary>
            public IncrementMethod BuildNumberType;

            /// <summary>The revision type.</summary>
            public IncrementMethod RevisionType;

            /// <summary>The build number format.</summary>
            public string BuildNumberFormat;

            /// <summary>The revision format.</summary>
            public string RevisionFormat;
        }
    }

}
