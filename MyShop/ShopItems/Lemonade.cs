using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    //Lemonade file
    public class Lemonade : ProductBase, IShopItem
    {

        public Lemonade(StockBox stockBox, string name, double price, string type, int weight, string brand) : base(stockBox, name, price, type, weight, brand)
        {

        }
    }
}
