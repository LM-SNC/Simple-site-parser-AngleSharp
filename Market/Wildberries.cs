using System;
using System.Collections.Generic;
using CataShopParser.Market;
using ClosedXML.Excel;
using ExtensionMethods;


namespace CataShopParser
{
    public class Wildberries : MarketPlace
    {
        private List<String> _existParams = new List<string>();
        private int _paramStart = 7;
        private int _paramNext;
        public override void CreateExcelFile(List<Item> items, Category category, FiltersTemplate filtersTemplate)
        {
            _paramNext = _paramStart;
            var wbook = new XLWorkbook();
            var ws = wbook.Worksheets.Add("WBCards");
            ws.Cell(1, 1).Value = "Категория";
            ws.Cell(1, 2).Value = "Бренд";
            ws.Cell(1, 3).Value = "Название";
            ws.Cell(1, 4).Value = "Артикул товара";
            ws.Cell(1, 5).Value = "Цена";
            ws.Cell(1, 6).Value = "Медиафайлы";

            for (int i = 2; i < items.Count + 2; i++)
            {
                ws.Cell(i, 1).Value = category.Name;
                ws.Cell(i, 2).Value = "Cata";
                ws.Cell(i, 3).Value = items[i-2].Name;
                ws.Cell(i, 4).Value = items[i-2].ART;
                ws.Cell(i, 5).Value = items[i-2].Price;
                ws.Cell(i, 6).Value = items[i-2].ImgMain;
                foreach (var param in items[i-2].Characteristics)
                {
                    int containsState = _existParams.MContains(param.Key);
                    if (containsState >= 0)
                    {
                        ws.Cell(i, containsState + _paramStart).Value = param.Value;
                    }
                    else
                    {
                        ws.Cell(1, _paramNext).Value = param.Key;
                        ws.Cell(i, _paramNext++).Value = param.Value;
                        _existParams.Add(param.Key);
                    }
                }
            }

            for (int i = _paramStart; i < _paramNext; i++)
            {
                for (int j = 2; j < items.Count + 2; j++)
                {
                    String value = ws.Cell(j, i).Value as string;
                    if (filtersTemplate.OverridedChValue.ContainsKey(value))
                        ws.Cell(j, i).Value = filtersTemplate.OverridedChValue[value];
                    
                }
            }
            
            for (int i = _paramStart; i < _paramNext; i++)
            {
                String value = ws.Cell(1, i).Value as string;
                if (filtersTemplate.OverridedCharacteristics.ContainsKey(value ?? string.Empty))
                    ws.Cell(1, i).Value = filtersTemplate.OverridedCharacteristics[value];
                
                if (filtersTemplate.ExceptCharacteristics.Contains(value))
                    for (int j = 1; j < items.Count + 2; j++)
                        ws.Cell(j, i).Value = "";
                
            }


            wbook.SaveAs("WBCards.xlsx");
        }
    }
}