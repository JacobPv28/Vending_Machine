using System;
using System.Collections.Generic;
using vendingMachine.Controller;
namespace vendingMachine.View
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("          Vending Machine Menu       ");
                Console.WriteLine("=====================================\n");
                Console.WriteLine("Please choose an option: \n1) Provider.\n2) Customer.\n3) Exit.");
                String UserValidation = Console.ReadLine();
                int UserValidation_1 = int.Parse(UserValidation);
                List<Consumable> consumables = Consumable.GetConsumables();

                switch (UserValidation_1)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("=====================================");
                            Console.WriteLine("          Provider Menu              ");
                            Console.WriteLine("=====================================\n");
                            Console.WriteLine("Please choose an option: \n1) Add a new consumable.\n2) Modify an existing consumable.\n3) Back to main menu.");
                            String ProviderOption = Console.ReadLine();
                            int ProviderOption_1 = int.Parse(ProviderOption);


                            switch (ProviderOption_1)
                            {
                                case 1:
                                    do
                                    {
                                        List<Consumable> newConsumables = new List<Consumable>();
                                        Console.WriteLine("Please enter the name of the new consumable:");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Please enter the price of the new consumable:");
                                        int price = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please enter the quantity of the new consumable:");
                                        int quantity = int.Parse(Console.ReadLine());
                                        newConsumables.Add(new Consumable(name, price, quantity));
                                        // Create a new Consumable
                                        Consumable newConsumable = new Consumable(name, price, quantity);
                                        // Add the new consumable to the list 
                                        consumables.Add(newConsumable);
                                        Console.WriteLine($"{name} has been added to the vending machine!"); ;
                                        // Add the new consumable to the list
                                        consumables.Add(newConsumable);
                                        // Get the updated list of consumables and print them out
                                        List<Consumable> allConsumables = Consumable.GetConsumables(newConsumables);
                                        foreach (var item in allConsumables)
                                        {
                                            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                                        }
                                        Console.WriteLine("\nWould you like to add another consumable? (y/n)");
                                        string response = Console.ReadLine().ToLower();
                                        while (response != "y" && response != "n")
                                        {
                                            Console.WriteLine("Invalid response. Please enter 'y' or 'n'.");
                                            response = Console.ReadLine().ToLower();
                                        }
                                    } while (Console.ReadLine().ToLower() == "y");
                                    Console.WriteLine("\n");
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.WriteLine("Please enter the name of the consumable you want to modify:");
                                        string nameToModify = Console.ReadLine();
                                        // Search for the consumable by name
                                        Consumable consumableToModify = consumables.FirstOrDefault(c => c.Name == nameToModify);
                                        if (consumableToModify == null)
                                        {
                                            Console.WriteLine("Consumable not found.");
                                            break;
                                        }
                                        Console.WriteLine("Please enter the new name of the consumable (leave blank to keep current name):");
                                        string newName = Console.ReadLine();
                                        Console.WriteLine("Please enter the new price of the consumable (leave blank to keep current price):");
                                        string newPriceString = Console.ReadLine();
                                        int newPrice;
                                        if (int.TryParse(newPriceString, out newPrice) == false)
                                        {
                                            newPrice = consumableToModify.Price;
                                        }
                                        Console.WriteLine("Please enter the new quantity of the consumable (leave blank to keep current quantity):");
                                        string newQuantityString = Console.ReadLine();
                                        int newQuantity;
                                        if (int.TryParse(newQuantityString, out newQuantity) == false)
                                        {
                                            newQuantity = consumableToModify.Quantity;
                                        }
                                        consumableToModify.ModifyConsumable(newName, newPrice, newQuantity);
                                        Console.WriteLine("Consumable modified successfully.");
                                        Console.WriteLine("Modified list of consumables:");
                                        foreach (var item in consumables)
                                        {
                                            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
                                        }
                                        Console.WriteLine("\nWould you like to add another consumable? (y/n)");
                                    } while (Console.ReadLine().ToLower() == "y");
                                    break;

                                case 3:
                                    // Return to main menu
                                    break;

                                default:
                                    Console.WriteLine("Invalid input. Please enter a valid option.");
                                    break;
                            }

                            // If the user chose option 3, break out of the provider menu loop
                            if (ProviderOption_1 == 3)
                            {
                                break;
                            }
                        }
                        break;

                    case 2:
                        while (true)
                        {
                            Console.WriteLine("=====================================");
                            Console.WriteLine("          Customer Menu              ");
                            Console.WriteLine("=====================================\n");
                            Console.WriteLine("Please choose an option: \n1) Buy a consumable.\n2) Back to main menu.\n3) Check individual price.");
                            String CustomerOption = Console.ReadLine();
                            int CustomerOption_1 = int.Parse(CustomerOption);

                            switch (CustomerOption_1)
                            {
                                case 1:
                                    Console.WriteLine("Hello Customer!");
                                    Console.WriteLine("Here is the list of available products:\n");
                                    // Print the list of consumables to the console
                                    Console.WriteLine("Name\tPrice\tQuantity");
                                    foreach (var item in consumables)
                                    {
                                        Console.WriteLine($"Name: {item.Name} | Price: {item.Price} | Quantity: {item.Quantity}");
                                    }
                                    Console.WriteLine("\nPlease enter the name of the product you want to buy:\n");
                                    string productToBuy = Console.ReadLine();
                                    // Search for the consumable by name
                                    Consumable consumableToBuy = consumables.FirstOrDefault(c => c.Name == productToBuy);

                                    if(consumableToBuy == null)
                        {
                                        Console.WriteLine("Product not found.\n");
                                        break;
                                    }
                                    int insertedMoney = 0;
                                    while (true)
                                    {
                                        Console.WriteLine("Please insert a bill of 1000, 2000, or 5000 COP:");
                                        int bill = int.Parse(Console.ReadLine());
                                        if (bill == 1000 || bill == 2000 || bill == 5000)
                                        {
                                            insertedMoney += bill;
                                            if (insertedMoney < consumableToBuy.Price)
                                            {
                                                Console.WriteLine($"Inserted: {insertedMoney}. Insufficient funds. Please insert more bills.");
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid bill denomination. Please insert a bill of 1000, 2000, or 5000 COP.");
                                        }
                                    }
                                    if (consumableToBuy.Quantity <= 0)
                                    {
                                        Console.WriteLine($"Sorry, {consumableToBuy.Name} is out of stock.\n");
                                        break;
                                    }
                                    if (insertedMoney < consumableToBuy.Price)
                                    {
                                        Console.WriteLine("Insufficient funds.\n");
                                        break;
                                    }
                                    // Calculate the change and return it to the customer
                                    int change = 0;
                                    if (insertedMoney > consumableToBuy.Price)
                                    {
                                        change = insertedMoney - consumableToBuy.Price;
                                        // Calculate the number of coins of each denomination in the change
                                        int numCoins500 = change / 500;
                                        int numCoins200 = (change % 500) / 200;
                                        int numCoins100 = ((change % 500) % 200) / 100;
                                        int numCoins50 = (((change % 500) % 200) % 100) / 50;
                                        Console.WriteLine($"You have purchased {consumableToBuy.Name}. Thank you for shopping with us!\n");
                                        Console.WriteLine($"Your change is {change} COP\n, Which is composed of:\n{numCoins500} coins of 500 COP\n{numCoins200} coins of 200 COP\n{numCoins100} coins of 100 COP\n{numCoins50} coins of 50 COP\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You have purchased {consumableToBuy.Name}. Thank you for shopping with us!\n");
                                    }
                                    // Update the quantity of the purchased consumable in the database
                                    consumableToBuy.ModifyConsumable(consumableToBuy.Name, consumableToBuy.Price, consumableToBuy.Quantity - 1);
                                    // Ask if the customer wants to buy another product or return to the main menu
                                    Console.WriteLine("Do you want to buy another product? (y/n)");
                                    string buyAgainChoice = Console.ReadLine().ToLower();
                                    if (buyAgainChoice == "n")
                                    {
                                        break;
                                    }
                                    break;

                                case 2:

                                    break;

                                case 3:
                                    // Next, you could prompt the user to enter a name to search for:
                                    Console.WriteLine("Enter the name of the consumable you want to search for:");
                                    string name = Console.ReadLine();

                                    // Then, you could call the SearchConsumableLinq method to find the consumable with the matching name:
                                    Consumable consumable = Consumable.SearchConsumableLinq(name);

                                    // Finally, you could display the result to the user:
                                    if (consumable != null)
                                    {
                                        Console.WriteLine($"Found {consumable.Name} with price {consumable.Price} and quantity {consumable.Quantity}\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Could not find consumable with name {name}\n");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Invalid input. Please enter a valid option.");
                                    break;
                            }
                            if (CustomerOption_1 == 2)
                            {
                                break;
                            }
                        }
                        break;

                    case 3:
                        // Exit the application
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
     