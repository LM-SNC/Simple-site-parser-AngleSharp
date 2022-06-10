using System;

namespace CataShopParser
{
    public class Category
    {
        public String Url;
        public String Name;

        public Category(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}