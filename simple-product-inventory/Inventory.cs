using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Inventory
    {
        public static List<Product> stock = new List<Product>(); //list of type products to store products
        public static int choice; //parameter to store choice of user
        public static double sum = 0; //parameter to store sum 


        public static void printChoices()
        {
            //Get user input for operation 
            Console.WriteLine("Press 1 for adding a new product;" +
                              "\nPress 2 to add stock to existing product;" +
                              "\nPress 3 to calculate total value of a product;" +
                              "\nPress 4 to calculate total value of the inventory;" +
                              "\nPress 0 to exit.");
            choice = Convert.ToInt32(Console.ReadLine());

            //exit program if 0 is entered
            if (choice == 0) { Environment.Exit(0); }
            else if (choice < 1 || choice > 4) { Console.WriteLine("Invalid choice, try again."); printChoices(); }

            switch (choice)
            {
                //algorithm for adding product
                case 1:
                    Console.WriteLine("What type of product would you like to add?\n" +
                                      "Press 1 for Shirt;" +
                                      "\nPress 2 for Trousers;" +
                                      "\nPress 3 for Sunglasses;" +
                                      "\nPress 4 for Hat.");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    string title, colour, type, protection;
                    double price;
                    int quantity =1;
                    Product product;

                    //if choice=1; add product depending on type
                    switch (temp)
                    {
                        //Add product of shirt type
                        case 1: //shirt
                            Console.WriteLine("Enter title:");
                            title = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter price:");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter colour:");
                            colour = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter quantity:");
                            quantity = Convert.ToInt32(Console.ReadLine());
                            product = new Shirt(title, colour, price,quantity);
                            stock.Add(product);
                            choice = 0;
                            printChoices();
                            break;

                        //Add product of trousers type
                        case 2: //trousers
                            Console.WriteLine("Enter title:");
                            title = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter price:");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter colour:");
                            colour = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter quantity:");
                            quantity = Convert.ToInt32(Console.ReadLine());
                            product = new Trousers(title, colour, price,quantity);
                            stock.Add(product);
                            printChoices();
                            break;

                        //Add product of sunglasses type 
                        case 3: //Sunglasses
                            Console.WriteLine("Enter title:");
                            title = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter price:");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter colour:");
                            colour = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter protection:");
                            protection = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter type:");
                            type = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter quantity:");
                            quantity = Convert.ToInt32(Console.ReadLine());
                            product = new sunGlasses(title, colour, price, protection, type,quantity);
                            stock.Add(product);
                            printChoices();
                            break;

                        //Add product of hat type 
                        case 4: //Hat
                            Console.WriteLine("Enter title:");
                            title = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter price:");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter colour:");
                            colour = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter type:");
                            type = (Console.ReadLine().ToString());
                            Console.WriteLine("Enter quantity:");
                            quantity = Convert.ToInt32(Console.ReadLine());
                            product = new Hat(title, colour, price, type,quantity);
                            stock.Add(product);
                            printChoices();
                            break;
                            default: Console.WriteLine("Invalid input."); break;
                    }
                    break;

                //if choice=2, add stock to existing product
                case 2:
                    int stockid;
                    int nquantity;
                    Console.WriteLine("To which product you want to add stock?");

                    //show all products and get user input depending on its placement on the list
                    for(int i=0;i<stock.Count;i++)
                    {
                        Console.WriteLine("Press {0} to stock to product with title: {1}",i,stock[i].title);
                    }
                    stockid=Convert.ToInt32(Console.ReadLine());

                    //if user input isnt out of bounds add stock to the exact product
                    if (stock.Count > stockid && stockid < stock.Count)
                    {
                        Console.WriteLine("Enter quantity: ");
                        nquantity = Convert.ToInt32(Console.ReadLine());
                        stock[stockid].quantity += nquantity;
                        printChoices();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                //If choice=3; calculate a products total value
                case 3:
                    Console.WriteLine("Which product's total value you want to calculate?");
                    Console.WriteLine("Press 1 for shirts;" +
                                      "\nPress 2 for trousers;" +
                                      "\nPress 3 for sunglasses;" +
                                      "\nPress 4 for hats.");
                    temp = Convert.ToInt32(Console.ReadLine());
                    string tip = "tip";
                    switch (temp)
                    {
                        //calculate value of shirts
                        case 1:
                            for (int i = 0; i < stock.Count; i++)
                            {
                                if (stock[i].GetType().Name=="Shirt")
                                {
                                    sum += stock[i].price*stock[i].quantity;

                                }
                                tip = "Shirts";
                                Console.WriteLine("\nTotal value of {0} is {1}.\n", tip, sum); sum = 0;
                                printChoices();
                            }
                            break;
                        //calculate value of trousers
                        case 2:
                            for (int i = 0; i < stock.Count; i++)
                            {
                                while (stock[i].GetType().Name.Equals("Trousers"))
                                {
                                    sum += stock[i].price*stock[i].quantity;
                                }
                                tip = "Trousers";
                                Console.WriteLine("\nTotal value of {0} is {1}.\n", tip, sum); sum = 0;
                                printChoices();
                            }
                            break;

                        //calculate value of sunglasses
                        case 3:
                            for (int i = 0; i < stock.Count; i++)
                            {
                                while (stock[i].GetType().Equals("sunGlasses"))
                                {
                                    sum += stock[i].price*stock[i].quantity;
                                }
                                tip = "Sunglasses";
                                Console.WriteLine("\nTotal value of {0} is {1}.\n", tip, sum); sum = 0;
                                printChoices();
                            }
                            
                            break;

                        //calculate value of Hats
                        case 4:
                            for (int i = 0; i < stock.Count; i++)
                            {
                                while (stock[i].GetType().Equals("Hat"))
                                {
                                    sum += stock[i].price* stock[i].quantity;
                                }
                                tip = "Hats";
                                Console.WriteLine("\nTotal value of {0} is {1}.\n", tip, sum); sum = 0;
                                printChoices();
                            }
                            break;
                        default: Console.WriteLine("Invalid input."); break;
                    }
                    
                    break;

                //if choice=4; calculate total value of all products
                case 4:
                    for(int i=0;i<stock.Count;i++)
                    {
                        sum += stock[i].price*stock[i].quantity;
                    }
                    Console.WriteLine("\nTotal value of all products is {0}.\n", sum); sum = 0;
                    printChoices();
                    break;
            }
        
        }
    }
}
