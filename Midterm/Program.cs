public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // TODO: Initialize the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // TODO: Update the item's price with the new price.
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // TODO: Increase the item's stock quantity by the additional quantity.
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // TODO: Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
        QuantityInStock -= quantitySold;

    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // TODO: Return true if the item is in stock (quantity > 0), otherwise false.
        if(QuantityInStock > 0)
        {
            return true;
        }
        return false;
    }

    // Print item details
    public void PrintDetails()
    {
        // Format the price so it look proper
        string formattedPrice = Price.ToString("0.00");
        // TODO: Print the details of the item (name, id, price, and stock quantity).
        Console.WriteLine($"Details of the {ItemName}: \nname: {ItemName}; \nid: {ItemId}; \nprice: {formattedPrice} Cad; \nin stock: {QuantityInStock}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 1. Print details of all items.
        // 2. Sell some items and then print the updated details.
        // 3. Restock an item and print the updated details.
        // 4. Check if an item is in stock and print a message accordingly.

        bool customerInteraction = true;

        while (customerInteraction)
        {
            // Display options for customer interaction
            Console.WriteLine("Choose an Action:");
            Console.WriteLine("1. Print details of all items.");
            Console.WriteLine("2. Sell items.");
            Console.WriteLine("3. Restock an item.");
            Console.WriteLine("4. Check if an item is in stock.");
            Console.WriteLine("5. Update item price.");
            Console.WriteLine("6. Exit.");
            Console.WriteLine();

            // Get customer choice
            Console.Write("Enter your choice (1-6): ");

            // This will prevent the program from crashing if the user enters anything else besides 1-5 (character or any special character)
            bool validActionInput = int.TryParse(Console.ReadLine(), out int choiceAction);

            if (!validActionInput || choiceAction < 1 || choiceAction > 6)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                continue;
            }

            switch (choiceAction)
            {
                case 1:
                    Console.WriteLine("Details of all items");
                    Console.WriteLine();
                    item1.PrintDetails();
                    Console.WriteLine();
                    item2.PrintDetails();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Sell items:");
                    Console.WriteLine();
                    Console.WriteLine("Choose an item to sell:");
                    Console.WriteLine($"1. {item1.ItemName}");
                    Console.WriteLine($"2. {item2.ItemName}");
                    Console.WriteLine();
                    Console.Write("Enter your choice (1-2): ");
                    Console.WriteLine();

                    //we stay here until we get correct restock quantity
                    while (true)
                    {
                        bool validSell = int.TryParse(Console.ReadLine(), out int choiceSell);
                        if (!validSell || choiceSell < 1 || choiceSell > 2)
                        {
                            Console.WriteLine("Invalid input. Please enter 1 or 2.");
                            continue;
                        }

                        //we stay here until we get correct restock quantity
                        while (true)
                        {
                            Console.WriteLine($"Enter quantity to sell {(choiceSell == 1 ? item1.ItemName : item2.ItemName)}: ");
                            bool validQuantitySell = int.TryParse(Console.ReadLine(), out int quantitySell);
                            if (!validQuantitySell || quantitySell < 1)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid quantity.");
                                continue;
                            }
                            if (choiceSell == 1)
                            {
                                if (item1.QuantityInStock == 0)
                                {
                                    Console.WriteLine($"Sorry, we out of stock for this {item1.ItemName}");
                                    Console.WriteLine();
                                    break;
                                }
                                else if (quantitySell > item1.QuantityInStock)
                                {
                                    Console.WriteLine("Sorry, we don't have that many items.");
                                    Console.WriteLine();
                                    continue; // We stay in the same menu if the quantity is invalid
                                }
                                else
                                {
                                    item1.SellItem(quantitySell);
                                    Console.WriteLine();
                                    item1.PrintDetails();
                                    Console.WriteLine();
                                }
                            }
                            else if (choiceSell == 2)
                            {
                                if (item2.QuantityInStock == 0)
                                {
                                    Console.WriteLine($"Sorry, we out of stock for this {item1.ItemName}");
                                    break;
                                }
                                else if (quantitySell > item2.QuantityInStock)
                                {
                                    Console.WriteLine("Sorry, we don't have that many items.");
                                    continue; // We stay in the same menu if the quantity is invalid
                                }
                                else
                                {
                                    item2.SellItem(quantitySell);
                                    Console.WriteLine();
                                    item2.PrintDetails();
                                    Console.WriteLine();
                                }
                            }
                            break;
                        }
                        break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Restock items:");
                    Console.WriteLine();
                    Console.WriteLine("Choose an item to restock:");
                    Console.WriteLine($"1. {item1.ItemName}");
                    Console.WriteLine($"2. {item2.ItemName}");
                    Console.WriteLine();
                    Console.Write("Enter your choice (1-2): ");
                    Console.WriteLine();

                    //we stay here until we get correct restock quantity
                    while (true)
                    {
                        bool validRestock = int.TryParse(Console.ReadLine(), out int choiceRestock);
                        if (!validRestock || choiceRestock < 1 || choiceRestock > 2)
                        {
                            Console.WriteLine("Invalid input. Please enter 1 or 2.");
                            continue;
                        }

                        //we stay here until we get correct restock quantity
                        while(true)
                        {
                            Console.WriteLine($"Enter quantity to restock {(choiceRestock == 1 ? item1.ItemName : item2.ItemName)}: ");
                            bool validQuantityRestock = int.TryParse(Console.ReadLine(), out int quantityRestock);
                            if (!validQuantityRestock || quantityRestock < 1)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid quantity.");
                                continue;
                            }
                            if (choiceRestock == 1)
                            {
                                item1.RestockItem(quantityRestock);
                                Console.WriteLine();
                                item1.PrintDetails();
                                Console.WriteLine();
                            }
                            else if (choiceRestock == 2)
                            {
                                item2.RestockItem(quantityRestock);
                                Console.WriteLine();
                                item2.PrintDetails();
                                Console.WriteLine();
                            }
                            break;
                        }
                        break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Checking stock of items:");
                    Console.WriteLine();
                    Console.WriteLine($"Laptop is{(item1.IsInStock() ? "" : " not")} in stock.");
                    Console.WriteLine($"{(item1.QuantityInStock == 1 ? "1 Laptop left" : $"{item1.QuantityInStock} Laptops left")}");
                    Console.WriteLine($"Smartphone is{(item2.IsInStock() ? "" : " not")} in stock.");
                    Console.WriteLine($"{(item2.QuantityInStock == 1 ? "1 Smartphone left" : $"{item2.QuantityInStock} Smartphones left")}");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Update Item Price:");
                    Console.WriteLine($"1. {item1.ItemName}");
                    Console.WriteLine($"2. {item2.ItemName}");
                    Console.WriteLine();
                    Console.Write("Enter your choice (1-2): ");
                    Console.WriteLine();

                    //we stay here until we get correct restock quantity
                    while (true)
                    {
                        bool validPrice = int.TryParse(Console.ReadLine(), out int choicePrice);
                        if (!validPrice || choicePrice < 1 || choicePrice > 2)
                        {
                            Console.WriteLine("Invalid input. Please enter 1 or 2.");
                            continue;
                        }
                        //we stay here until we get correct restock quantity
                        while (true)
                        {
                            Console.WriteLine($"Enter new item price {(choicePrice == 1 ? item1.ItemName : item2.ItemName)}: ");
                            if (!double.TryParse(Console.ReadLine(), out double newPrice))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid price.");
                                continue;
                            }
                            if (choicePrice == 1)
                            {
                                item1.UpdatePrice(newPrice);
                                Console.WriteLine();
                                item1.PrintDetails();
                                Console.WriteLine();
                            }
                            else if (choicePrice == 2)
                            {
                                item2.UpdatePrice(newPrice);
                                Console.WriteLine();
                                item2.PrintDetails();
                                Console.WriteLine();
                            }
                            break;
                        }
                        break;
                    }
                    break;
                case 6:
                    customerInteraction = false;
                    Console.WriteLine("Thanks for choosing us. \nHave a great day!");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
       
    }
}
