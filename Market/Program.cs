using System.Threading.Tasks;
using CataShopParser.Market;

namespace CataShopParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FiltersTemplate filtersTemplate = new FiltersTemplate();
            //filtersTemplate.OverridedCharacteristics.Add("Производительность, м3/ч", "TESTT");
            //filtersTemplate.OverridedCharacteristics.Add("Дисплей", "Нет блин экран");
            filtersTemplate.ExceptCharacteristics.Add("Гарантия");
            
            filtersTemplate.ExceptCharacteristics.Add("Бренд");
            filtersTemplate.ExceptCharacteristics.Add("Цвет");
            
            filtersTemplate.OverridedChValue.Add("Cata(Испания)", "Cata");
           // filtersTemplate.OverridedChValue.Add("Мин. ширина встраивания, см", "Ширина встраивания");
            filtersTemplate.OverridedCharacteristics.Add("Уровень шума, дБ", "Уровень звука/шума");
            filtersTemplate.OverridedCharacteristics.Add("Высота, см", "Высота предмета");
            filtersTemplate.OverridedCharacteristics.Add("Вес, кг", "Вес без упаковки (кг)");

           // filtersTemplate.ItemsLimit = 20;
            
            MarketProductBuilder marketProductBuilder = new MarketProductBuilder(Categories.KitchenHoods, 
                new Wildberries(), filtersTemplate);
            marketProductBuilder.Build();
        }
    }
    
    public class Categories
    {
        public static Category KitchenHoods = new Category("https://cata-shop.ru/kukhonnye-vytyazhki/?limit=1000",
            "Вытяжки кухонные");
        public static Category Ovens = new Category("https://cata-shop.ru/dukhovye-shkafy/?limit=1000",
            "Духовые шкафы");
        public static Category MicrowaveOvens = new Category("https://cata-shop.ru/mikrovolnovye-pechi/?limit=1000",
            "Микроволновые печи");
        public static Category ExtractorFans = new Category("https://cata-shop.ru/vytyazhnye-ventilyatory/?limit=1000",
            "Вытяжные вентиляторы");
        public static Category Dishwashers = new Category("https://cata-shop.ru/posudomoechnye-mashiny/?limit=1000",
            "Посудомоечные машины");
        public static Category AirPurifiers = new Category("https://cata-shop.ru/vozduhoochistiteli/?limit=1000",
            "Воздухоочистители");
        public static Category Filters = new Category("https://cata-shop.ru/filtry/?limit=1000",
            "Фильтры");
        public static Category CookingPanels = new Category("https://cata-shop.ru/varochnye-paneli/?limit=1000",
            "Варочные панели");
    }
}