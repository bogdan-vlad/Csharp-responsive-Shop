using MyShop.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyShop
{

    class Program
    {


        //thats your main execution method (like your index.js file)
        static void Main(string[] args)
        {







            Wallet myWallet = new Wallet(20);
            Stock myStock = new Stock();
            Basket myBasket = new Basket(2);



            StockBox stb = new StockBox(20);
            StockBox sb1 = new StockBox(20);
            StockBox sb2 = new StockBox(20);
            StockBox sb3 = new StockBox(20);

            Fruit lemon = new Fruit(sb1, "lemon", 2, "Tropical fruits", 1, "Lemonland");
            Fruit mango = new Fruit(sb1, "mango", 3, "Tropical fruits", 2, "Mangoland");
            Lemonade stillLemonade = new Lemonade(stb, "still lemonade", 2, "Lemonade", 2, "BrandStill");
            Lemonade stillLemonadeDuplicate = new Lemonade(stb, "still lemonade", 2, "Lemonade", 2, "BrandStill");
            Lemonade flavoured = new Lemonade(stb, "flavoured drink", 4, "Lemonade", 2, "BrandStill");
            Lemonade sparklingLemonade = new Lemonade(stb, "sparkling lemonade", 3, "Lemonade", 1, "BrandSparkling");
            Meat burger = new Meat(stb, "burger", 8, "Meat", 2, "BrandBurger");
            Meat crocodile = new Meat(sb2, "croc", 8, "Meat", 2, "BrandBurger");
            Meat chicken = new Meat(sb2, "chicken", 2, "Meat", 3, "BrandChicken");
            Meat lamb = new Meat(sb2, "lamb", 3, "Meat", 2, "BrandLamb");
            Bread white = new Bread(sb3, "Bread", 3, "bread", 2, "Hovis");
            Vegetables pepper = new Vegetables(sb3, "pepper", 3, "veg", 2, "veggie");


            myStock.AddStockBox(stb);
            myStock.AddStockBox(sb1);
            myStock.AddStockBox(sb2);
            myStock.AddStockBox(sb3);


            Console.WriteLine("Stockboxes available " + myStock.TotalStockBoxes());
            Console.WriteLine("======Welcome to the shop.======");
            Console.WriteLine("Your wallet has £" + myWallet.MyCash + " available.");








            while (true)
            {
                Dictionary<int, string> typeAllOptions = new Dictionary<int, string>();
                int optionAllIndx = 0;
                foreach (string typeStr in myStock.GetAllAvailableTypes)
                {
                    typeAllOptions.Add(optionAllIndx, typeStr);

                    Console.WriteLine(typeStr + " -- select " + optionAllIndx++);
                }

                Console.WriteLine("Select a value from above.");
                int answer = int.Parse(Console.ReadLine());
                Console.WriteLine("You selected " + answer);
                string selectedOption = typeAllOptions[answer];





                Dictionary<int, string> myItemsDictionary = new Dictionary<int, string>();
                int allItems = 0;
                foreach (string itemName in myStock.GetAvailableDistinctItemsByType(selectedOption))
                {
                    int currentIdx = allItems++;
                    myItemsDictionary.Add(currentIdx, itemName);
                    ////List<IShopItem> aa = myStock.GetAvailableItemsByType(myStr);
                    //foreach (KeyValuePair<int, IShopItem> itm in showAllItems)
                    //{
                    Console.WriteLine(string.Format("Item name {0} in stock {1}", itemName, myStock.GetAllItemCountByName(itemName)) + " select " + currentIdx);
                    //}
                }
                Console.WriteLine("Choose your item");
                int answerA = int.Parse(Console.ReadLine());
                Console.WriteLine("Selected " + answerA);
                selectedOption = myItemsDictionary[answerA];



                int answerB = -1;
                Console.WriteLine("You are about to buy " + selectedOption + " and we have " + myStock.GetAllItemCountByName(selectedOption) + " in stock.");
                Console.WriteLine("How many?");
                answerB = int.Parse(Console.ReadLine());
                int selectedOptionInt = answerB;

                if (answerB > myStock.GetAllItemCountByName(selectedOption))
                {
                    Console.WriteLine("The amount you entered is not valid. The stock is only " + myStock.GetAllItemCountByName(selectedOption) + ". Try again.");
                }
                else if (answerB == 0)
                {
                    Console.WriteLine("You cannot buy nothing.");
                }
                else if (answerB <= myStock.GetAllItemCountByName(selectedOption))
                {

                    List<IShopItem> tmpList = myStock.GetAvailableItemsByName(selectedOption).Take(answerB).ToList();
                    foreach(IShopItem item in tmpList)
                    {
                        item.MyStockBox.RemoveItem(item);
                    }
                    Console.WriteLine("You succefully purchased " + answerB + " " + selectedOption + ".");
                    Console.WriteLine("Available " + myStock.GetAllItemCountByName(selectedOption) + " " + selectedOption);
                    Console.WriteLine(myBasket.ItemsPriceBasket);
                }
                else
                {
                    Console.WriteLine("I didn't get that.");
                }



























                //string subOptions = showAllItems[answerA];


                //switch (answer)
                //{
                //    case 0:
                //        Console.WriteLine("Fruits department");
                //        if (myStock.TotalStockBoxes() != 0)
                //        {
                //            List<IShopItem> typeNameFruit = myStock.GetAvailableItemsByType("Tropical fruits");
                //            int optFrIDX = 0;
                //            foreach (IShopItem itm in typeNameFruit.Distinct())
                //            {
                //                Console.WriteLine(string.Format("Item name {0} currently in stock {1}", itm.Name, myStock.GetAllItemCountByName(itm.Name)) + " select " + optFrIDX++);
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No fruits left...");
                //        }
                //        break;
                //    case 1:
                //        Console.WriteLine("Lemonade department");
                //        if (myStock.TotalStockBoxes() != 0)
                //        {
                //            List<IShopItem> typeNameLemonade = myStock.GetAvailableItemsByType("Lemonade");
                //            int optLmIDX = 0;
                //            foreach (IShopItem itm in typeNameLemonade.Distinct())
                //            {
                //                Console.WriteLine(string.Format("Item name {0} currently in stock {1}", itm.Name, myStock.GetAllItemCountByName(itm.Name)) + " select " + optLmIDX++);
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No lemonade left...");
                //            Console.WriteLine("\t9. To return");
                //        }

                //        break;
                //    case 2:
                //        Console.WriteLine("Meat department");
                //        if (myStock.TotalStockBoxes() != 0)
                //        {
                //            List<IShopItem> typeNameMeat = myStock.GetAvailableItemsByType("Meat");

                //            foreach (IShopItem itm in typeNameMeat.Distinct())
                //            {
                //                Console.WriteLine(string.Format("Item name {0} currently in stock {1}", itm.Name, myStock.GetAllItemCountByName(itm.Name)));
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No meat left...");
                //            Console.WriteLine("\t9. To return");
                //        }
                //        break;
                //    case 3:
                //        Console.WriteLine("Veg department");
                //        if (myStock.TotalStockBoxes() != 0)
                //        {
                //            List<IShopItem> typeNameVeg = myStock.GetAvailableItemsByType("veg");

                //            foreach (IShopItem itm in typeNameVeg.Distinct())
                //            {
                //                Console.WriteLine(string.Format("Item name {0} currently in stock {1}", itm.Name, myStock.GetAllItemCountByName(itm.Name)));
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No veg left...");
                //            Console.WriteLine("\t9. To return");
                //        }
                //        break;
                //    case 4:
                //        Console.WriteLine("Bread department");
                //        if (myStock.TotalStockBoxes() != 0)
                //        {
                //            List<IShopItem> typeNameBread = myStock.GetAvailableItemsByType("bread");

                //            foreach (IShopItem itm in typeNameBread.Distinct())
                //            {
                //                Console.WriteLine(string.Format("Item name {0} currently in stock {1}", itm.Name, myStock.GetAllItemCountByName(itm.Name)));
                //            }
                //        }
                //        else
                //        {
                //            Console.WriteLine("No bread left...");
                //            Console.WriteLine("\t9. To return");
                //        }
                //        break;
                //    case 5:
                //        if (myBasket.ItemsPriceBasket > myWallet.MyCash)
                //        {
                //            Console.WriteLine("Your basket total cost is £" + myBasket.ItemsPriceBasket + " and your wallet has £" + myWallet.MyCash + " available.");
                //            Console.WriteLine("Unfortunately you don't have enough money.");
                //            Console.WriteLine("Need £" + Math.Abs(myBasket.ItemsPriceBasket - myWallet.MyCash) + " more to purchase all the items.");
                //        }
                //        else if (myBasket.ItemsPriceBasket <= myWallet.MyCash)
                //        {
                //            Console.WriteLine("You successfully paid. £" + Math.Abs(myBasket.ItemsPriceBasket - myWallet.MyCash) + " is left in the wallet.");
                //            Console.WriteLine("Thank you and have a good day!");
                //        }
                //        else
                //        {
                //            Console.WriteLine("Bye bye");
                //        }
                //        Environment.Exit(0);
                //        break;

                //    case 6:
                //        Console.WriteLine("Not valid");
                //        continue;
                //}



                //Console.WriteLine("Choose a value: ");
                //int answerA = int.Parse(Console.ReadLine());
                //Console.WriteLine("You selected " + answerA);
                //switch (answerA)
                //{
                //    case 0:
                //        if (myBasket.MaxItems == 0)
                //        {
                //            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        }
                //        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        {
                //            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetFruitByName("lemon").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        }
                //        else if (myStock.TotalStockBoxes() != 0)
                //        {
                //            sb1.GetFruit(lemon);
                //            myBasket.AddFruitBasket(lemon);
                //        }
                //        else
                //        {
                //            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetFruitByName("lemon").Name);
                //        }
                //        Console.WriteLine("Price is £" + myBasket.ItemsPriceBasket);
                //        Console.WriteLine("Available ");
                //        break;

                //        //                    case 1:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetFruitByName("mango").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.FruitStockRemain())
                //        //                        {
                //        //                            stb.GetFruit(mango);
                //        //                            myBasket.AddFruitBasket(mango);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.FruitStockRemain())
                //        //                        {
                //        //                            stb.GetFruit(mango);
                //        //                            myBasket.AddFruitBasket(mango);
                //        //                        }
                //        //                        else
                //        //                        {
                //        //                            Console.WriteLine("Basket is full and I couldn't add " + stb.GetFruitByName("mango").Name);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Available " + stb.FruitStockRemain());
                //        //                        break;
                //        //                    case 2:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetLemonadeByName("still lemonade").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.LemonadeStockRemain())
                //        //                        {
                //        //                            stb.GetLemonade(stillLemonade);
                //        //                            myBasket.AddLemonadeBasket(stillLemonade);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.LemonadeStockRemain())
                //        //                        {
                //        //                            stb.GetLemonade(stillLemonade);
                //        //                            myBasket.AddLemonadeBasket(stillLemonade);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Lemonade available " + stb.LemonadeStockRemain());
                //        //                        break;
                //        //                    case 3:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetLemonadeByName("sparkling lemonade").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.LemonadeStockRemain())
                //        //                        {
                //        //                            stb.GetLemonade(sparklingLemonade);
                //        //                            myBasket.AddLemonadeBasket(sparklingLemonade);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.LemonadeStockRemain())
                //        //                        {
                //        //                            stb.GetLemonade(sparklingLemonade);
                //        //                            myBasket.AddLemonadeBasket(sparklingLemonade);
                //        //                        }
                //        //                        else
                //        //                        {
                //        //                            Console.WriteLine("Basket is veryy full and I couldn't add " + stb.GetLemonadeByName("sparkling lemonade").Name);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Lemonade available " + stb.LemonadeStockRemain());
                //        //                        break;
                //        //                    case 4:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetMeatByName("burger").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(burger);
                //        //                            myBasket.AddMeatBasket(burger);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(burger);
                //        //                            myBasket.AddMeatBasket(burger);
                //        //                        }
                //        //                        else
                //        //                        {
                //        //                            Console.WriteLine("Basket is veryy full and I couldn't add " + stb.GetMeatByName("burger").Name);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Meat available " + stb.MeatStockRemain());
                //        //                        break;
                //        //                    case 5:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetMeatByName("chicken").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(chicken);
                //        //                            myBasket.AddMeatBasket(chicken);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(chicken);
                //        //                            myBasket.AddMeatBasket(chicken);
                //        //                        }
                //        //                        else
                //        //                        {
                //        //                            Console.WriteLine("Basket is full veryy and I couldn't add " + stb.GetMeatByName("chicken").Name);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Meat available " + stb.MeatStockRemain());
                //        //                        break;
                //        //                    case 6:
                //        //                        if (myBasket.MaxItems == 0)
                //        //                        {
                //        //                            Console.WriteLine("No products can be added to the basket. Check your MaxItems.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems == myBasket.TotalBasket())
                //        //                        {
                //        //                            Console.WriteLine("Basket is waaay to full and I couldn't add " + stb.GetMeatByName("lamb").Name + ". Check your Basket MaxItems if you want to purchase more.");
                //        //                        }
                //        //                        else if (myBasket.MaxItems >= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(lamb);
                //        //                            myBasket.AddMeatBasket(lamb);
                //        //                        }
                //        //                        else if (myBasket.MaxItems <= stb.MeatStockRemain())
                //        //                        {
                //        //                            stb.GetMeat(lamb);
                //        //                            myBasket.AddMeatBasket(lamb);
                //        //                        }
                //        //                        else
                //        //                        {
                //        //                            Console.WriteLine("Basket is veryyy full and I couldn't add " + stb.GetMeatByName("lamb").Name);
                //        //                        }
                //        //                        Console.WriteLine("The price is £" + myBasket.ItemsPriceBasket);
                //        //                        Console.WriteLine("Meat available " + stb.MeatStockRemain());
                //        //                        continue;
                //        //                }
                //        //            }

                //        //            }
                //        //        }
                //}
            }
        }
    }
}

























































//int count = myStock.CountFruitByName("mango");
//int countLemonade = myStock.CountLemonadeByName("still lemonade");
//int countMeat = myStock.CountMeatByName("burger");
//Console.ReadKey();

//int countType = myStock.TypeFruit("tropical");
//Console.ReadKey();




//List<string> myTmp = myStock.ListAllFruits;
//Console.ReadKey();

//List<string> myLemonade = myStock.ListAllLemonades;
//Console.ReadKey();

//List<string> myMeat = myStock.ListAllMeat;
//Console.ReadKey();




////counting the products by name
//public int CountFruitByName(string name)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetFruitName(name);
//    }
//    return count;
//}
//public int CountLemonadeByName(string name)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetLemonadeName(name);
//    }
//    return count;
//}
//public int CountMeatByName(string name)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetMeatName(name);
//    }
//    return count;
//}
////counting the products by type
//public int TypeFruit(string type)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetFruitType(type);
//    }
//    return count;
//}
//public int TypeLemonade(string type)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetLemonadeType(type);
//    }
//    return count;
//}
//public int TypeMeat(string type)
//{
//    int count = 0;
//    foreach (StockBox stb in MyStockBoxes)
//    {
//        count += stb.GetMeatType(type);
//    }
//    return count;
//}