using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    //Meat file
    public class Meat : ProductBase, IShopItem
    {
        public Meat(StockBox stockBox, string name, double price, string type, int weight, string brand) : base(stockBox, name, price, type, weight, brand)
        {

        }
    }
}
