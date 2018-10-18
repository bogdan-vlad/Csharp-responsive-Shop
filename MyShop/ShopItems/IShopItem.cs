using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    public interface IShopItem
    {
        StockBox MyStockBox { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Type { get; set; }
        int Weight { get; set; }
        string Brand { get; set; }
    }
}
