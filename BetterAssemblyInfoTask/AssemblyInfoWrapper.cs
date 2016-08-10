// ------------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfoWrapper.cs" company="">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    using JetBrains.Annotations;


    /// <summary>
    ///     Supports all classes in the .NET Framework class hierarchy and provides low-level services to derived classes.
    ///     This is the ultimate base class of all classes in the .NET Framework; it is the root of the type hierarchy.To
    ///     browse the .NET Framework source code for this type, see the Reference Source.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    internal class AssemblyInfoWrapper
    {
        /// <summary>The attribute boolean value pattern.</summary>
        private readonly Regex attributeBooleanValuePattern = new Regex(
            "\\((?<attributeValue>([tT]rue|[fF]alse))\\)", 
            RegexOptions.Compiled);

        /// <summary>The attribute index.</summary>
        private readonly Dictionary<string, int> attributeIndex = new Dictionary<string, int>();

        /// <summary>The attribute name pattern.</summary>
        private readonly Regex attributeNamePattern = new Regex(
            "[aA]ssembly:?\\s*(?<attributeName>\\w+)\\s*\\(", 
            RegexOptions.Compiled);

        /// <summary>The attribute string value pattern.</summary>
        private readonly Regex attributeStringValuePattern = new Regex("\"(?<attributeValue>.*?)\"", RegexOptions.Compiled);

        /// <summary>The multi line c sharp comment end pattern.</summary>
        private readonly Regex multiLineCSharpCommentEndPattern = new Regex(".*?\\*/", RegexOptions.Compiled);

        /// <summary>The multi line c sharp comment start pattern.</summary>
        private readonly Regex multiLineCSharpCommentStartPattern = new Regex("\\s*/\\*^\\*", RegexOptions.Compiled);

        /// <summary>The raw file lines.</summary>
        private readonly List<string> rawFileLines = new List<string>();

        /// <summary>The single line c sharp comment pattern.</summary>
        private readonly Regex singleLineCSharpCommentPattern = new Regex("\\s*//", RegexOptions.Compiled);

        /// <summary>The single line vb comment pattern.</summary>
        private readonly Regex singleLineVbCommentPattern = new Regex("\\s*'", RegexOptions.Compiled);


        /// <summary>Initializes a new instance of the <see cref="AssemblyInfoWrapper"/> class. </summary>
        /// <param name="filename">The filename.</param>
        public AssemblyInfoWrapper([NotNull] string filename)
        {
            var streamReader = File.OpenText(filename);
            var num = 0;
            var flag = false;
            string input;
            while ((input = streamReader.ReadLine()) != null)
            {
                this.rawFileLines.Add(input);
                if (this.singleLineCSharpCommentPattern.IsMatch(input) || this.singleLineVbCommentPattern.IsMatch(input))
                {
                    ++num;
                }
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
                    var matchCollection = this.attributeNamePattern.Matches(input);
                    if (matchCollection.Count > 0)
                    {
                        this.attributeIndex[matchCollection[0].Groups["attributeName"].Value] = num;
                    }

                    ++num;
                }
            }

            streamReader.Close();
        }


        /// <summary>The this.</summary>
        /// <param name="attribute">The attribute.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The <see cref="string"/>.</returns>
        [CanBeNull]
        public string this[[NotNull] string attribute]
        {
            get
            {
                if (!this.attributeIndex.ContainsKey(attribute))
                {
                    return (string)null;
                }

                var matchCollection1 = this.attributeStringValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]);
                if (matchCollection1.Count > 0)
                {
                    return matchCollection1[0].Groups["attributeValue"].Value;
                }

                var matchCollection2 = this.attributeBooleanValuePattern.Matches(
                    this.rawFileLines[this.attributeIndex[attribute]]);
                if (matchCollection2.Count > 0)
                {
                    return matchCollection2[0].Groups["attributeValue"].Value;
                }

                return (string)null;
            }

            set
            {
                if (!this.attributeIndex.ContainsKey(attribute))
                {
                    throw new ArgumentOutOfRangeException(
                        "attribute", 
                        string.Format("{0} is not an attribute in the specified AssemblyInfo.cs file", (object)attribute));
                }

                if (this.attributeStringValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]).Count > 0)
                {
                    this.rawFileLines[this.attributeIndex[attribute]] =
                        this.attributeStringValuePattern.Replace(
                            this.rawFileLines[this.attributeIndex[attribute]], 
                            "\"" + value + "\"");
                }
                else
                {
                    if (this.attributeBooleanValuePattern.Matches(this.rawFileLines[this.attributeIndex[attribute]]).Count <= 0)
                    {
                        return;
                    }

                    this.rawFileLines[this.attributeIndex[attribute]] =
                        this.attributeBooleanValuePattern.Replace(
                            this.rawFileLines[this.attributeIndex[attribute]], 
                            "(" + value + ")");
                }
            }
        }


        /// <summary>The write.</summary>
        /// <param name="streamWriter">The stream writer.</param>
        public void Write(StreamWriter streamWriter)
        {
            foreach (var rawFileLine in this.rawFileLines)
            {
                streamWriter.WriteLine(rawFileLine);
            }
        }
    }

}
