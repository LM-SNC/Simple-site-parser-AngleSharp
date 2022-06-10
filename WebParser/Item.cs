using System;
using System.Collections.Generic;
using System.IO;

namespace CataShopParser
{
    public class Item
    {
        public String Name;
        public String Price;
        public String ART;
        public String ImgMain;
        public List<String> Imags;
        public Dictionary<String, String> Characteristics = new Dictionary<string, string>();
    }
}