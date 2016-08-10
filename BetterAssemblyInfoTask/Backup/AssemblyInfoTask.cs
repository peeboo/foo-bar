// Decompiled with JetBrains decompiler
// Type: Microsoft.Build.Extras.AssemblyInfo
// Assembly: BetterAssemblyInfoTask, Version=1.0.51130.0, Culture=neutral, PublicKeyToken=null
// MVID: D9EBB705-C6FB-4157-8976-CD566C3B02A5
// Assembly location: G:\Devel\git-src\Emby.combined\Emby\modules\SimpleInjector\src\BuildTools\BetterAssemblyInfoTask.dll

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;

namespace Microsoft.Build.Extras
{
  public class AssemblyInfo : Task
  {
    private AssemblyInfo.AssemblyVersionSettings assemblyVersionSettings;
    private string rawAssemblyBuildNumberType;
    private string rawAssemblyRevisionType;
    private string maxAssemblyVersion;
    private AssemblyInfo.AssemblyVersionSettings assemblyFileVersionSettings;
    private string rawAssemblyFileBuildNumberType;
    private string rawAssemblyFileRevisionType;
    private string maxAssemblyFileVersion;
    private string assemblyTitle;
    private string assemblyDescription;
    private string assemblyConfiguration;
    private string assemblyCompany;
    private string assemblyProduct;
    private string assemblyCopyright;
    private string assemblyTrademark;
    private string assemblyCulture;
    private string assemblyGuid;
    private bool assemblyIncludeSigningInformation;
    private string assemblyDelaySign;
    private string assemblyKeyFile;
    private string assemblyKeyName;
    private string comVisible;
    private ITaskItem[] assemblyInfoFiles;

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

    public override bool Execute()
    {
      FileInfo fileInfo = (FileInfo) null;
      StreamWriter streamWriter = (StreamWriter) null;
      if (!this.ParseIncrementProperties() || !this.ValidateIncrementProperties())
        return false;
      this.MaxAssemblyVersion = "0.0.0.0";
      this.MaxAssemblyFileVersion = "0.0.0.0";
      foreach (ITaskItem assemblyInfoFile in this.AssemblyInfoFiles)
      {
        AssemblyInfoWrapper assemblyInfo = new AssemblyInfoWrapper(assemblyInfoFile.ItemSpec);
        if (!this.ValidateFileEntries(assemblyInfo, assemblyInfoFile.ItemSpec))
          return false;
        this.Log.LogMessage(MessageImportance.Low, "Updating assembly info for {0}", (object) assemblyInfoFile.ItemSpec);
        Version versionToUpdate1 = new Version(assemblyInfo["AssemblyVersion"]);
        this.UpdateAssemblyVersion(ref versionToUpdate1, this.assemblyVersionSettings);
        assemblyInfo["AssemblyVersion"] = versionToUpdate1.ToString();
        this.UpdateMaxVersion(ref this.maxAssemblyVersion, assemblyInfo["AssemblyVersion"]);
        Version versionToUpdate2 = new Version(assemblyInfo["AssemblyFileVersion"]);
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
          streamWriter = new StreamWriter((Stream) fileInfo.OpenWrite());
          assemblyInfo.Write(streamWriter);
          streamWriter.Close();
          File.Copy(fileInfo.FullName, assemblyInfoFile.ItemSpec, true);
        }
        finally
        {
          if (streamWriter != null)
            streamWriter.Close();
          if (fileInfo != null)
            fileInfo.Delete();
        }
      }
      return true;
    }

    private void UpdateAssemblyVersion(ref Version versionToUpdate, AssemblyInfo.AssemblyVersionSettings requestedVersion)
    {
      if (requestedVersion.Version != null)
      {
        this.Log.LogMessage(MessageImportance.Low, "\tUpdating assembly version to {0}", (object) requestedVersion.Version);
        versionToUpdate.VersionString = requestedVersion.Version;
      }
      if (requestedVersion.MajorVersion != null)
      {
        this.Log.LogMessage(MessageImportance.Low, "\tUpdating major version to {0}", (object) requestedVersion.MajorVersion);
        versionToUpdate.MajorVersion = requestedVersion.MajorVersion;
      }
      if (requestedVersion.MinorVersion != null)
      {
        this.Log.LogMessage(MessageImportance.Low, "\tUpdating minor version to {0}", (object) requestedVersion.MinorVersion);
        versionToUpdate.MinorVersion = requestedVersion.MinorVersion;
      }
      string str = "";
      bool flag = requestedVersion.BuildNumberType == IncrementMethod.DateString && requestedVersion.RevisionType == IncrementMethod.AutoIncrement;
      if (flag)
        str = versionToUpdate.BuildNumber;
      versionToUpdate.BuildNumber = this.UpdateVersionProperty(versionToUpdate.BuildNumber, requestedVersion.BuildNumberType, requestedVersion.BuildNumber, requestedVersion.BuildNumberFormat, "\tUpdating build number to {0}");
      if (flag && str != versionToUpdate.BuildNumber)
        versionToUpdate.Revision = "-1";
      versionToUpdate.Revision = this.UpdateVersionProperty(versionToUpdate.Revision, requestedVersion.RevisionType, requestedVersion.Revision, requestedVersion.RevisionFormat, "\tUpdating revision number to {0}");
      this.Log.LogMessage(MessageImportance.Low, "\tFinal assembly version is {0}", (object) versionToUpdate.ToString());
    }

    private void UpdateProperty(AssemblyInfoWrapper assemblyInfo, string propertyName)
    {
      string str = (string) this.GetType().GetProperty(propertyName).GetValue((object) this, (object[]) null);
      if (str == null)
        return;
      assemblyInfo[propertyName] = str;
      this.Log.LogMessage(MessageImportance.Low, "\tUpdating {0} to \"{1}\"", (object) propertyName, (object) str);
    }

    private string UpdateVersionProperty(string versionNumber, IncrementMethod method, string value, string format, string logMessage)
    {
      this.Log.LogMessage(MessageImportance.Low, "\tUpdate method is {0}", (object) method.ToString());
      if (format == "")
        format = "0";
      switch (method)
      {
        case IncrementMethod.NoIncrement:
          if (value == null)
            return versionNumber;
          this.Log.LogMessage(MessageImportance.Low, logMessage, (object) value);
          return value;
        case IncrementMethod.AutoIncrement:
          int num = int.Parse(versionNumber) + 1;
          this.Log.LogMessage(MessageImportance.Low, logMessage, (object) num.ToString(format));
          return num.ToString(format);
        case IncrementMethod.DateString:
          string @string = DateTime.Now.ToString(format);
          this.Log.LogMessage(MessageImportance.Low, logMessage, (object) @string);
          return @string;
        default:
          return "";
      }
    }

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
        this.Log.LogError("Unable to create temporary file: {0}", (object) ex.Message);
        return (FileInfo) null;
      }
      return fileInfo;
    }

    private void UpdateMaxVersion(ref string maxVersion, string newVersion)
    {
      if (newVersion == null)
        return;
      System.Version version = new System.Version(maxVersion);
      if (!(new System.Version(newVersion) > version))
        return;
      maxVersion = newVersion;
    }

    private bool ParseIncrementProperties()
    {
      string str = string.Join(", ", Enum.GetNames(typeof (IncrementMethod)));
      if (this.AssemblyBuildNumberType == null)
      {
        this.assemblyVersionSettings.BuildNumberType = IncrementMethod.NoIncrement;
      }
      else
      {
        if (!Enum.IsDefined(typeof (IncrementMethod), (object) this.AssemblyBuildNumberType))
        {
          this.Log.LogError("The value specified for AssemblyBuildNumberType is invalid. It must be one of: {0}", (object) str);
          return false;
        }
        this.assemblyVersionSettings.BuildNumberType = (IncrementMethod) Enum.Parse(typeof (IncrementMethod), this.AssemblyBuildNumberType);
      }
      if (this.AssemblyRevisionType == null)
      {
        this.assemblyVersionSettings.RevisionType = IncrementMethod.NoIncrement;
      }
      else
      {
        if (!Enum.IsDefined(typeof (IncrementMethod), (object) this.AssemblyRevisionType))
        {
          this.Log.LogError("The value specified for AssemblyRevisionType is invalid. It must be one of: {0}", (object) str);
          return false;
        }
        this.assemblyVersionSettings.RevisionType = (IncrementMethod) Enum.Parse(typeof (IncrementMethod), this.AssemblyRevisionType);
      }
      if (this.AssemblyFileBuildNumberType == null)
      {
        this.assemblyFileVersionSettings.BuildNumberType = IncrementMethod.NoIncrement;
      }
      else
      {
        if (!Enum.IsDefined(typeof (IncrementMethod), (object) this.AssemblyFileBuildNumberType))
        {
          this.Log.LogError("The value specified for AssemblyFileBuildNumberType is invalid. It must be one of: {0}", (object) str);
          return false;
        }
        this.assemblyFileVersionSettings.BuildNumberType = (IncrementMethod) Enum.Parse(typeof (IncrementMethod), this.AssemblyFileBuildNumberType);
      }
      if (this.AssemblyFileRevisionType == null)
      {
        this.assemblyFileVersionSettings.RevisionType = IncrementMethod.NoIncrement;
      }
      else
      {
        if (!Enum.IsDefined(typeof (IncrementMethod), (object) this.AssemblyFileRevisionType))
        {
          this.Log.LogError("The value specified for AssemblyFileRevisionType is invalid. It must be one of: {0}", (object) str);
          return false;
        }
        this.assemblyFileVersionSettings.RevisionType = (IncrementMethod) Enum.Parse(typeof (IncrementMethod), this.AssemblyFileRevisionType);
      }
      return true;
    }

    private bool ValidateIncrementProperties()
    {
      if (this.assemblyVersionSettings.BuildNumberType == IncrementMethod.DateString && this.assemblyVersionSettings.BuildNumberFormat == null)
      {
        this.Log.LogError("The version increment method for AssemblyBuildNumber was set to DateString, but AssemblyBuildNumberFormat was not specified. Both properties must be set to use a date string as a build number.");
        return false;
      }
      if (this.assemblyVersionSettings.RevisionType == IncrementMethod.DateString && this.assemblyVersionSettings.RevisionFormat == null)
      {
        this.Log.LogError("The version increment method for AssemblyRevision was set to DateString, but AssemblyRevisionFormat was not specified. Both properties must be set to use a date string as a revision.");
        return false;
      }
      if (this.assemblyFileVersionSettings.BuildNumberType == IncrementMethod.DateString && this.AssemblyFileBuildNumberFormat == null)
      {
        this.Log.LogError("The version increment method for AssemblyFileBuildNumber was set to DateString, but AssemblyFileBuildNumberFormat was not specified. Both properties must be set to use a date string as a build number.");
        return false;
      }
      if (this.assemblyFileVersionSettings.RevisionType != IncrementMethod.DateString || this.AssemblyFileRevisionFormat != null)
        return true;
      this.Log.LogError("The version increment method for AssemblyFileRevision was set to DateString, but AssemblyFileRevisionFormat was not specified. Both properties must be set to use a date string as a revision.");
      return false;
    }

    private bool ValidateFileEntries(AssemblyInfoWrapper assemblyInfo, string filename)
    {
      if ((this.AssemblyBuildNumber != null || this.AssemblyRevision != null || (this.AssemblyMajorVersion != null || this.AssemblyMinorVersion != null)) && assemblyInfo["AssemblyVersion"] == null)
      {
        this.Log.LogError("Unable to update the AssemblyVersion for {0}: No stub entry for AssemblyVersion was found in the AssemblyInfo file.", (object) filename);
        return false;
      }
      if ((this.AssemblyFileBuildNumber != null || this.AssemblyFileRevision != null || (this.AssemblyFileMajorVersion != null || this.AssemblyFileMinorVersion != null)) && assemblyInfo["AssemblyFileVersion"] == null)
      {
        this.Log.LogError("Unable to update the AssemblyFileVersion for {0}: No stub entry for AssemblyFileVersion was found in the AssemblyInfo file.", (object) filename);
        return false;
      }
      return this.ValidateFileEntry(this.AssemblyCompany, assemblyInfo, "AssemblyCompany", filename) && this.ValidateFileEntry(this.AssemblyConfiguration, assemblyInfo, "AssemblyConfiguration", filename) && (this.ValidateFileEntry(this.AssemblyCopyright, assemblyInfo, "AssemblyCopyright", filename) && this.ValidateFileEntry(this.AssemblyCulture, assemblyInfo, "AssemblyCulture", filename)) && (this.ValidateFileEntry(this.AssemblyDescription, assemblyInfo, "AssemblyDescription", filename) && this.ValidateFileEntry(this.AssemblyProduct, assemblyInfo, "AssemblyProduct", filename) && (this.ValidateFileEntry(this.AssemblyTitle, assemblyInfo, "AssemblyTitle", filename) && this.ValidateFileEntry(this.AssemblyTrademark, assemblyInfo, "AssemblyTrademark", filename))) && (!this.AssemblyIncludeSigningInformation || this.ValidateFileEntry(this.AssemblyDelaySign, assemblyInfo, "AssemblyDelaySign", filename) && this.ValidateFileEntry(this.AssemblyKeyFile, assemblyInfo, "AssemblyKeyFile", filename) && this.ValidateFileEntry(this.AssemblyKeyName, assemblyInfo, "AssemblyKeyName", filename));
    }

    private bool ValidateFileEntry(string taskAttributeValue, AssemblyInfoWrapper assemblyInfo, string fileAttribute, string filename)
    {
      if (taskAttributeValue == null || assemblyInfo[fileAttribute] != null)
        return true;
      this.Log.LogError("Unable to update the {0} for {1}: No stub entry for {0} was found in the AssemblyInfo file.", (object) fileAttribute, (object) filename);
      return false;
    }

    private struct AssemblyVersionSettings
    {
      public string MajorVersion;
      public string MinorVersion;
      public string BuildNumber;
      public string Revision;
      public string Version;
      public IncrementMethod BuildNumberType;
      public IncrementMethod RevisionType;
      public string BuildNumberFormat;
      public string RevisionFormat;
    }
  }
}
