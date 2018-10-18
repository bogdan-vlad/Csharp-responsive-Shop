using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.ShopItems
{
    //Basket file
    public class Basket
    {
        public List<IShopItem> MyBasketCost = new List<IShopItem>();

        public int MaxItems;

        List<Fruit> Fruits = new List<Fruit>();
        List<Lemonade> Lemonades = new List<Lemonade>();
        List<Meat> Meats = new List<Meat>();

        public Basket(int maxitems)
        {
            MaxItems = maxitems;

        }
        //add products to basket
        public void AddFruitBasket(Fruit fruitToBasket)
        {
            if (TotalBasket() < MaxItems)
            {
                Fruits.Add(fruitToBasket);
            }
            else
            {
                Console.WriteLine("Basket is way to full full and I couldn't add " + fruitToBasket.Name);
            }
        }
        public void AddLemonadeBasket(Lemonade lemonadeToBasket)
        {
            if (TotalBasket() < MaxItems)
            {
                Lemonades.Add(lemonadeToBasket);
            }
            else
            {
                Console.WriteLine("Basket is full and I couldn't add " + lemonadeToBasket.Name);
            }
        }
        public void AddMeatBasket(Meat meatToBasket)
        {
            if (TotalBasket() < MaxItems)
            {
                Meats.Add(meatToBasket);

            }
            else
            {
                Console.WriteLine("Basket is full and I couldn't add " + meatToBasket.Name);
            }
        }
        //remove products from basket
        public Fruit RemoveFruitBasket(Fruit fruitOutBasket)
        {
            Fruit outFruit;
            outFruit = Fruits.FirstOrDefault(f => f.Name == fruitOutBasket.Name);
            if (outFruit != null)
            {
                Fruits.Remove(outFruit);
            }
            return outFruit;
        }
        public Lemonade RemoveLemonadeBasket(Lemonade lemonadeOutBasket)
        {
            Lemonade outLemonade;
            outLemonade = Lemonades.FirstOrDefault(l => l.Name == lemonadeOutBasket.Name);
            if (outLemonade != null)
            {
                Lemonades.Remove(lemonadeOutBasket);
            }
            return outLemonade;
        }
        public Meat RemoveMeatBasket(Meat meatOutBasket)
        {
            Meat outMeat;
            outMeat = Meats.FirstOrDefault(m => m.Name == meatOutBasket.Name);
            if (meatOutBasket != null)
            {
                Meats.Remove(meatOutBasket);
            }
            return outMeat;
        }
        //products total count
        public int FruitCount()
        {
            return Fruits.Count();
        }
        public int LemonadeCount()
        {
            return Lemonades.Count();
        }
        public int MeatCount()
        {
            return Meats.Count();
        }
        public int TotalBasket()
        {
            return FruitCount() + LemonadeCount() + MeatCount();
        }
        //total amount basket
        public double ItemsPriceBasket
        {
            get
            {
                double fruitPrice = Fruits.Sum(f => f.Price);
                double lemonadePrice = Lemonades.Sum(l => l.Price);
                double meatsPrice = Meats.Sum(m => m.Price);

                return fruitPrice + lemonadePrice + meatsPrice;
            }
        }

    }
}
