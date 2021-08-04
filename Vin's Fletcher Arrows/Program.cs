using System;

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Console.Title = "Vin's Fletcher Arrows";

//Main goes here

//Create a new Arrow based on Requests

Arrow.ArrowHead orderedArrowHead = AskForArrowHead("What would you want your Arrowhead made of? Wood, Steel or Obsidian?");
Arrow.Fletching orderedFletching = AskForFletching("What kind of fletching would you like? Plastic, Turkey Feathers or Goose Fethers?");

//Assemble Arrow and get length
Arrow orderedArrow = new Arrow(GetUIntegerRange("How long should the Arrow be? Between 60 and 100.", 60, 100), orderedArrowHead, orderedFletching);
//Find out total Cost
float orderCost = GetCost(orderedArrow);
//Inform Customer
Console.WriteLine($"The total Cost of your Arrow will be {orderCost} Gold. Thank you for Ordering from Fletcher's Arrows!");

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
Arrow.ArrowHead AskForArrowHead(string message) //Turn readline string into an Arrowhead output
{
    Console.WriteLine(message);
    string input = Console.ReadLine();
    if (input == "Steel")
        return Arrow.ArrowHead.Steel;
    if (input == "Obsidian")
        return Arrow.ArrowHead.Obsidian;
    if (input == "Wood")
        return Arrow.ArrowHead.Obsidian;
    else
    {
        Console.WriteLine("Please pick one of the provided Materials!");
        return AskForArrowHead(message);
    } 
}
Arrow.Fletching AskForFletching(string message) //Turn readline string into a Fletching output
{
    Console.WriteLine(message);
    string input = Console.ReadLine();
    if (input == "Plastic")
        return Arrow.Fletching.Plastic;
    if (input == "Goose Feathers" || input == "Goose")
        return Arrow.Fletching.GooseFeathers;
    if (input == "Turkey Feathers" || input == "Turkey")
        return Arrow.Fletching.TurkeyFeathers;
    else
    {
        Console.WriteLine("Please select on of the provided Materials!");
        return AskForFletching(message);
    }
}
float GetCost(Arrow arrow) //Calculates the cost of a full Arrow Order
{
    float finalCost = 0;

  switch (arrow.ArrowHeeadType)
    {
        case Arrow.ArrowHead.Steel:
            finalCost += 10;
            break;
        case Arrow.ArrowHead.Wood:
            finalCost += 3;
            break;
        case Arrow.ArrowHead.Obsidian:
            finalCost += 5;
            break;
        default:
            finalCost += 0;
            break;
    }
    switch (arrow.FletchingType)
    {
        case Arrow.Fletching.GooseFeathers:
            finalCost += 3;
            break;
        case Arrow.Fletching.Plastic:
            finalCost += 10;
            break;
        case Arrow.Fletching.TurkeyFeathers:
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
class Arrow
{
    //Fields
    private uint _lengthInCM;
    private ArrowHead _arrowHead;
    private Fletching _fletching;

    //Enums
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
   
    //Properties
    public uint LengthInCM => _lengthInCM;
    public ArrowHead ArrowHeeadType => _arrowHead;
    public Fletching FletchingType => _fletching; 

    //Constructor
    public Arrow(uint lengthInCM, ArrowHead arrowHead, Fletching fletching)
    {
        _lengthInCM = lengthInCM;
        _arrowHead = arrowHead;
        _fletching = fletching;
    }
}