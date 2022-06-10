using System;
using System.Collections.Generic;
using CataShopParser.Market;

namespace CataShopParser
{
    public class MarketProductBuilder
    {
        private Category category;
        private MarketPlace marketPlace;
        private FiltersTemplate _filtersTemplate;
      
        
        public MarketProductBuilder(Category category, MarketPlace marketPlace, FiltersTemplate filtersTemplate)
        {
            this.category = category;
            this.marketPlace = marketPlace;
            _filtersTemplate = filtersTemplate;
        }

        public void Build()
        {
            ParsManager parsManager = new ParsManager();
            List<Item> parsedItems = parsManager.Start(category.Url, _filtersTemplate.ItemsLimit, _filtersTemplate.Offset).Result;

            marketPlace.CreateExcelFile(parsedItems, category, _filtersTemplate);
        }
    }
}