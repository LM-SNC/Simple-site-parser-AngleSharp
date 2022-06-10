using System;
using System.Collections.Generic;

namespace CataShopParser.Market
{
    public class FiltersTemplate
    {
        public Dictionary<String, String> OverridedCharacteristics { get; set; }
        public Dictionary<String, String> OverridedChValue { get; set; }
        public List<String> ExceptCharacteristics { get; set; }
        public int ItemsLimit = 10000;
        public int Offset = 0;

        public FiltersTemplate()
        {
            OverridedCharacteristics = new Dictionary<string, string>();
            OverridedChValue = new Dictionary<string, string>();
            ExceptCharacteristics = new List<string>();
        }
    }
}