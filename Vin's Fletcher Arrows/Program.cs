using System;

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Console.Title = "Vin's Fletcher Arrows";

//Variables go here

Arrow orderedArrow = null;
string orderType = null;

//Main goes here

Console.WriteLine("Welcome to Vin Fletcher's Arrow Shop. What would you like to buy today?");
Console.WriteLine("1: A Beginner Arrow (With a wooden arrowhead, goose feather fletching and sporting a 75cm shaft");
Console.WriteLine("2: An Elite Arrow (With a steel arrowshead, plastic fletching and sporting a 95cm shaft!)");
Console.WriteLine("3: A Marksman Arrow (With a steel arrowhead, goose feather fletching and sporting a 65cm shaft!)");
Console.WriteLine("4: A custom order (Specifications provided BY YOU!");
string request = Console.ReadLine();

switch (request)
{
    case "1":
    case "Beginner Arrow":
        orderedArrow = Arrow.CreateBeginnerArrow();
        orderType = "Beginner Arrow";
        break;
    case "2":
    case "Elite Arrow":
        orderedArrow = Arrow.CreateEliteArrow();
        orderType = "Elite Arrow";
        break;
    case "3":
    case "Marksman Arrow":
        orderedArrow = Arrow.CreateMarksmanArrow();
        orderType = "Marksman Arrow";
        break;
    case "4":
    case "custom order":
        //Create a new Arrow based on Requests
        ArrowHead orderedArrowHead = AskForArrowHead("What would you want your Arrowhead made of? Wood, Steel or Obsidian?");
        Fletching orderedFletching = AskForFletching("What kind of fletching would you like? Plastic, Turkey Feathers or Goose Fethers?");
        //Get Length and assemble arrow
        orderedArrow = new Arrow(GetUIntegerRange("How long should the Arrow be? Between 60 and 100.", 60, 100), orderedArrowHead, orderedFletching);
        orderType = "custom order";
        break;
}
//Find out total Cost

float orderCost = GetCost(orderedArrow);
//Inform Customer

Console.WriteLine($"The total Cost of your {orderType} will be {orderCost} Gold. Thank you for Ordering from Fletcher's Arrows!");

//Methods go here

uint GetUIntegerRange(string message, uint min, uint max) //Turns ReadLine String into an uint between min and max
{
    Console.WriteLine(message);
    uint number = Convert.ToUInt32(Console.ReadLine());
    if (number > max || number < min)
    {
        Console.WriteLine("Please submit a number within the acceptable Parameters!");
        return GetUIntegerRange(message, min, max);
    }
    else
        return number;
}
ArrowHead AskForArrowHead(string message) //Turn readline string into an Arrowhead output
{
    Console.WriteLine(message);
    string input = Console.ReadLine();
    if (input == "Steel")
        return ArrowHead.Steel;
    if (input == "Obsidian")
        return ArrowHead.Obsidian;
    if (input == "Wood")
        return ArrowHead.Obsidian;
    else
    {
        Console.WriteLine("Please pick one of the provided Materials!");
        return AskForArrowHead(message);
    } 
}
Fletching AskForFletching(string message) //Turn readline string into a Fletching output
{
    Console.WriteLine(message);
    string input = Console.ReadLine();
    if (input == "Plastic")
        return Fletching.Plastic;
    if (input == "Goose Feathers" || input == "Goose")
        return Fletching.GooseFeathers;
    if (input == "Turkey Feathers" || input == "Turkey")
        return Fletching.TurkeyFeathers;
    else
    {
        Console.WriteLine("Please select on of the provided Materials!");
        return AskForFletching(message);
    }
}
float GetCost(Arrow arrow) //Calculates the cost of a full Arrow Order
{
    float finalCost = 0;

  switch (arrow.ArrowHeead)
    {
        case ArrowHead.Steel:
            finalCost += 10;
            break;
        case ArrowHead.Wood:
            finalCost += 3;
            break;
        case ArrowHead.Obsidian:
            finalCost += 5;
            break;
        default:
            finalCost += 0;
            break;
    }
    switch (arrow.Fletching)
    {
        case Fletching.GooseFeathers:
            finalCost += 3;
            break;
        case Fletching.Plastic:
            finalCost += 10;
            break;
        case Fletching.TurkeyFeathers:
            finalCost += 5;
            break;
        default:
            finalCost += 0;
            break;
    }
    finalCost = finalCost + Convert.ToSingle(arrow.LengthInCM) * 0.05f;
    return finalCost;
}

// Classes and Enums go here

//Enums for Arrow
public enum ArrowHead
{
    Steel,
    Wood,
    Obsidian
}
public enum Fletching
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}
class Arrow
{
    //Fields
    private uint _lengthInCM;
    private ArrowHead _arrowHead;
    private Fletching _fletching;
   
    //Properties
    public uint LengthInCM => _lengthInCM;
    public ArrowHead ArrowHeead => _arrowHead;
    public Fletching Fletching => _fletching; 

    //Constructor
    public Arrow(uint lengthInCM, ArrowHead arrowHead, Fletching fletching)
    {
        _lengthInCM = lengthInCM;
        _arrowHead = arrowHead;
        _fletching = fletching;
    }

    //Premade Orders
    public static Arrow CreateEliteArrow()
    {
        Arrow EliteArrow = new Arrow(95, ArrowHead.Steel, Fletching.Plastic);
        return EliteArrow;
    }
    public static Arrow CreateBeginnerArrow()
    {
        Arrow BeginnerArrow = new Arrow(75, ArrowHead.Wood, Fletching.GooseFeathers);
        return BeginnerArrow;
    }
    public static Arrow CreateMarksmanArrow()
    {
        Arrow MarksmanArrow = new Arrow(65, ArrowHead.Steel, Fletching.GooseFeathers);
        return MarksmanArrow;
    }
}