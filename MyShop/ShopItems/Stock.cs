using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{


    //Stock class will behave like StockBox
    public class Stock
    {


        List<StockBox> MyStockBoxes = new List<StockBox>();
        public void AddStockBox(StockBox stb)
        {
            MyStockBoxes.Add(stb);
        }
        public double TotalStockBoxes()
        {
            return MyStockBoxes.Count();
        }


        List<StockBox> RemovedStockBoxes = new List<StockBox>();
        public void RemoveFromStockBox (StockBox stb)
        {
            RemovedStockBoxes.Remove(stb);
        }


        public IEnumerable<string> GetAllAvailableTypes
        {
            get
            {
                IEnumerable<string> myTypes = Enumerable.Empty<string>();
                foreach (StockBox stb in MyStockBoxes)
                {
                    myTypes = myTypes.Concat(stb.GetAvailableItemTypes());
                }

                return myTypes.Distinct();
            }
        }

        public List<IShopItem> GetAvailableItemsByType(string typeName)
        {
            List<IShopItem> retList = new List<IShopItem>();
            foreach (StockBox stb in MyStockBoxes)
            {
                retList = retList.Concat(stb.GetItemsByType(typeName)).ToList();
            }

            return retList;
        }

        public List<IShopItem> GetAvailableItemsByName(string name)
        {
            List<IShopItem> retList = new List<IShopItem>();
            foreach (StockBox stb in MyStockBoxes)
            {
                retList = retList.Concat(stb.GetItemsByName(name)).ToList();
            }

            return retList;
        }

        public int GetAllItemCountByName(string name)
        {
            int retCount = 0;
            foreach (StockBox stb in MyStockBoxes)
            {
                retCount += stb.GetItemCountByName(name);
            }

            return retCount;
        }

        public List<string> GetAvailableDistinctItemsByType (string typeName)
        {
            List<IShopItem> retList = new List<IShopItem>();
            foreach (StockBox stb in MyStockBoxes)
            {
                retList = retList.Concat(stb.GetItemsByType(typeName)).ToList();
            }

            return retList.Select(i => i.Name).Distinct().ToList();
        }
    
    }
}
