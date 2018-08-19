using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Stores defintions for objects required to read json data from UrbanDictionary.com
/// </summary>
namespace PotatoBot
{
    public class UrbanDictionaryResponse
    {
        public UrbanDictionaryDef[] List { get; set; }
    }
    public class UrbanDictionaryDef
    {
        public string Word;
        public string Definition;
        public string PermaLink;
        public string Example;
    }
}
