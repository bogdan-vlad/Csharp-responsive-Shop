using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    //stockbox
    public class StockBox
    {

        //variable types - fields
        public int MyCount;
        public bool MyBool = false;
        public int MaxStock = 0;

        public List<IShopItem> MyItems = new List<IShopItem>();

        public List<IShopItem> ItemToRemove = new List<IShopItem>();

 
        public StockBox(int maxstock)
        {
            MaxStock = maxstock;
        }

 


        public void AddItem(IShopItem item)
        {
            MyItems.Add(item);
        }

        public void RemoveItem(IShopItem remItem)
        {
            MyItems.Remove(remItem);
        }


 



        //get items

        public IEnumerable<string> GetAvailableItemTypes()
        {
            return MyItems.Select(i => i.Type).Distinct();
        }
       

        public List<IShopItem> GetItemsByType(string type)
        {
            return MyItems.FindAll(i => i.Type == type);
        }

        public List<IShopItem> GetItemsByName(string name)
        {
            return MyItems.FindAll(i => i.Name == name);
        }

        public int GetItemCountByName(string name)
        {
            return MyItems.Count(i => i.Name == name);
        }

    }
}
