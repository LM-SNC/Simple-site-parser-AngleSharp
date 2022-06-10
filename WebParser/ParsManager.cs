using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace CataShopParser
{
    public class ParsManager
    {
        public async Task<List<Item>> Start(String productUrl, int limit, int offset)
        {
            List<Item> items = new List<Item>();
            
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var address = productUrl;

            IDocument document;
            IHtmlCollection<IElement> cells;

            Console.WriteLine("Open main page");
            document = await context.OpenAsync(address);
            cells = document.GetElementsByClassName("grid-block");
            
            List<Task<IDocument>> inItems = new List<Task<IDocument>>();
            for (int b = offset; b < cells.Length; b++)
            {
                if (b >= limit)
                    break;
                Console.WriteLine("Item " + (b + 1) + " process...");
                Item item = new Item();
                var main = cells[b].GetElementsByClassName("caption")[0].GetElementsByTagName("a")[0];
                item.Name = main.TextContent;
                item.Price = Regex.Replace(cells[b].GetElementsByClassName("price text-muted")[0].TextContent,
                    "[^0-9]", "");
                item.ART = cells[b].GetElementsByClassName("code")[0].LastChild.TextContent;
                
                inItems.Add(context.OpenAsync(main.GetAttribute("href")));
                items.Add(item);
                Task.Delay(7000/cells.Length).Wait();
            }
            
            for (int c = 0; c < inItems.Count; c++)
            {
                Console.WriteLine("Parse item");
                items[c].ImgMain = inItems[c].Result.GetElementsByClassName("thumbnail")[0].GetAttribute("href");
                
                await inItems[c];
                if (inItems[c].Result.GetElementsByClassName("tab-pane fade in active").Length > 0)
                {
                    var itemParams = inItems[c].Result.GetElementsByClassName("tab-pane fade in active")[0].GetElementsByTagName("td");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int i = 0; i < itemParams.Length; i += 2)
                        items[c].Characteristics.Add(itemParams[i].TextContent, "'" + itemParams[i + 1].TextContent);
                }
            }

            return items;
        }
    }
}