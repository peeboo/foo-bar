// Decompiled with JetBrains decompiler
// Type: Microsoft.Build.Extras.AssemblyInfoWrapper
// Assembly: BetterAssemblyInfoTask, Version=1.0.51130.0, Culture=neutral, PublicKeyToken=null
// MVID: D9EBB705-C6FB-4157-8976-CD566C3B02A5
// Assembly location: G:\Devel\git-src\Emby.combined\Emby\modules\SimpleInjector\src\BuildTools\BetterAssemblyInfoTask.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft.Build.Extras
{
  internal class AssemblyInfoWrapper
  {
    private List<string> rawFileLines = new List<string>();
    private Dictionary<string, int> attributeIndex = new Dictionary<string, int>();
    private Regex attributeNamePattern = new Regex("[aA]ssembly:?\\s*(?<attributeName>\\w+)\\s*\\(", RegexOptions.Compiled);
    private Regex attributeStringValuePattern = new Regex("\"(?<attributeValue>.*?)\"", RegexOptions.Compiled);
    private Regex attributeBooleanValuePattern = new Regex("\\((?<attributeValue>([tT]rue|[fF]alse))\\)", RegexOptions.Compiled);
    private Regex singleLineCSharpCommentPattern = new Regex("\\s*//", RegexOptions.Compiled);
    private Regex singleLineVbCommentPattern = new Regex("\\s*'", RegexOptions.Compiled);
    private Regex multiLineCSharpCommentStartPattern = new Regex("\\s*/\\*^\\*", RegexOptions.Compiled);
    private Regex multiLineCSharpCommentEndPattern = new Regex(".*?\\*/", RegexOptions.Compiled);

    public string this[string attribute]
    {
      get
      {
        if (!this.attributeIndex.ContainsKey(attribute))
          return (string) null;
        MatchCollection matchCollection1 = this.attributeStringValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]);
        if (matchCollection1.Count > 0)
          return matchCollection1[0].Groups["attributeValue"].Value;
        MatchCollection matchCollection2 = this.attributeBooleanValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]);
        if (matchCollection2.Count > 0)
          return matchCollection2[0].Groups["attributeValue"].Value;
        return (string) null;
      }
      set
      {
        if (!this.attributeIndex.ContainsKey(attribute))
          throw new ArgumentOutOfRangeException("attribute", string.Format("{0} is not an attribute in the specified AssemblyInfo.cs file", (object) attribute));
        if (this.attributeStringValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]).Count > 0)
        {
          this.rawFileLines[this.attributeIndex[attribute]] = this.attributeStringValuePattern.Replace(this.rawFileLines[this.attributeIndex[attribute]], "\"" + value + "\"");
        }
        else
        {
          if (this.attributeBooleanValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]).Count <= 0)
            return;
          this.rawFileLines[this.attributeIndex[attribute]] = this.attributeBooleanValuePattern.Replace(this.rawFileLines[this.attributeIndex[attribute]], "(" + value + ")");
        }
      }
    }

    public AssemblyInfoWrapper(string filename)
    {
      StreamReader streamReader = File.OpenText(filename);
      int num = 0;
      bool flag = false;
      string input;
      while ((input = streamReader.ReadLine()) != null)
      {
        this.rawFileLines.Add(input);
        if (this.singleLineCSharpCommentPattern.IsMatch(input) || this.singleLineVbCommentPattern.IsMatch(input))
          ++num;
        else if (this.multiLineCSharpCommentStartPattern.IsMatch(input))
        {
          ++num;
          flag = true;
        }
        else if (this.multiLineCSharpCommentEndPattern.IsMatch(input) && flag)
        {
          ++num;
          flag = false;
        }
        else if (flag)
        {
          ++num;
        }
        else
        {
          MatchCollection matchCollection = this.attributeNamePattern.Matches(input);
          if (matchCollection.Count > 0)
            this.attributeIndex[matchCollection[0].Groups["attributeName"].Value] = num;
          ++num;
        }
      }
      streamReader.Close();
    }

    public void Write(StreamWriter streamWriter)
    {
      foreach (string rawFileLine in this.rawFileLines)
        streamWriter.WriteLine(rawFileLine);
    }
  }
}
