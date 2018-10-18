using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    //productBase file
    public class ProductBase: IShopItem
    {
        public StockBox MyStockBox { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public string Brand { get; set; }

        public ProductBase(StockBox stockBox, string name, double price, string type, int weight, string brand)
        {
            MyStockBox = stockBox;
            Name = name;
            Price = price;
            Type = type;
            Weight = weight;
            Brand = brand;
            MyStockBox.AddItem(this);
        }
    }
}
