// Decompiled with JetBrains decompiler
// Type: Microsoft.Build.Extras.Version
// Assembly: BetterAssemblyInfoTask, Version=1.0.51130.0, Culture=neutral, PublicKeyToken=null
// MVID: D9EBB705-C6FB-4157-8976-CD566C3B02A5
// Assembly location: G:\Devel\git-src\Emby.combined\Emby\modules\SimpleInjector\src\BuildTools\BetterAssemblyInfoTask.dll

using System;
using System.Text.RegularExpressions;

namespace Microsoft.Build.Extras
{
  internal class Version
  {
    private string versionString;
    private string majorVersion;
    private string minorVersion;
    private string buildNumber;
    private string revision;

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

    public Version()
    {
      this.MajorVersion = "1";
      this.MinorVersion = "0";
      this.BuildNumber = "0";
      this.Revision = "0";
    }

    public Version(string version)
    {
      this.ParseVersion(version);
    }

    private void ParseVersion(string version)
    {
      MatchCollection matchCollection = new Regex("(?<majorVersion>(\\d+|\\*))\\.(?<minorVersion>(\\d+|\\*))\\.(?<buildNumber>(\\d+|\\*))\\.(?<revision>(\\d+|\\*))", RegexOptions.Compiled).Matches(version);
      if (matchCollection.Count != 1)
        throw new ArgumentException("version", "The specified string is not a valid version number");
      this.MajorVersion = matchCollection[0].Groups["majorVersion"].Value;
      this.MinorVersion = matchCollection[0].Groups["minorVersion"].Value;
      this.BuildNumber = matchCollection[0].Groups["buildNumber"].Value;
      this.Revision = matchCollection[0].Groups["revision"].Value;
      this.versionString = version;
    }

    public override string ToString()
    {
      return string.Format("{0}.{1}.{2}.{3}", (object) this.MajorVersion, (object) this.MinorVersion, (object) this.BuildNumber, (object) this.Revision);
    }
  }
}
