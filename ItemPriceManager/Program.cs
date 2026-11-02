using System.Linq;




string? runAgain = "y";

while (runAgain == "y")
{

    List<Item> items = new List<Item>();  // The list you create must associate itself with a class having objects
// we are adding into list items and using properties of our Item class 
// items.Add( new Item {});

string? choice = "y";
while ( choice == "y" )
{
    Console.WriteLine("Enter item name: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))    // validate item name
    {
        Console.WriteLine("Item name cannot be empty.");
        continue;
    }

    Console.WriteLine("Enter item price: ");
    string? priceInput = Console.ReadLine();
    if (decimal.TryParse(priceInput, out decimal price)) // parse creates a decimal variable to hold the converted result
    {
        items.Add(new Item
        {
            ItemName = name,
            ItemPrice = price
        });

        Console.WriteLine($"Valid price:  {price}");
    }
    else    // create item & add to the list otherwise, display error
    {
        Console.WriteLine("Invalid price, Please enter a valid decimal: ");
    }

    Console.WriteLine("Do you want to add another item? (y/n)"); // asking whether user wants another item to be added
    choice = Console.ReadLine();
    
}
foreach( var item in items)     // display all items using foreach loop
    {
        Console.WriteLine($"Item: {item.ItemName} | Price: {item.ItemPrice}");      // string interpolation
    }

    Console.WriteLine("Do you want to search any item ?");
    string? searchChoice = Console.ReadLine()?.ToLower();
    // searchChoice = searchChoice == "y" ? "y" : "n";
    if (searchChoice == "y")
{
    // items = full list
    // FirstOrDefault = finds the first matching item or returns null

    Console.WriteLine("Enter Item name to search: ");
    string? searchItemName = Console.ReadLine();

    var foundItem = items.FirstOrDefault(
        item => string.Equals(
            item.ItemName,
            searchItemName,
            StringComparison.OrdinalIgnoreCase )
    );

    if (foundItem != null)
    {
        Console.WriteLine($"Item found: {foundItem.ItemName}");
        Console.WriteLine($"Item price: {foundItem.ItemPrice}");
    }
    else
    {
        Console.WriteLine("Item not found");
    }
    
}

    Console.WriteLine("Do you want to run the program again ? (y/n)");
    runAgain = Console.ReadLine()?.ToLower();  
}

  


public class Item
{
    public required string ItemName { get; set; } // get set allows the property to be read and changed
    public decimal ItemPrice { get; set; }

}

