
using System;
using static System.Collections.Specialized.BitVector32;

Equipment cooker = new Equipment("cooker", "Daewoo", true);
Equipment dishwasher = new Equipment("dishwasher", "Bosh", true);
Equipment fridge = new Equipment("fridge", "Cylinda", true);
Equipment damaged = new Equipment("damaged", "not working", false);
List<IKitchenAppliance> thing = new List<IKitchenAppliance>();
Kitchen Ikea = new Kitchen();
Ikea.AddNewItem(fridge);
Ikea.AddNewItem(damaged);
Ikea.AddNewItem(dishwasher);
Ikea.AddNewItem(cooker);
Ikea.Lista();

bool menu = true;
while (menu)
{
    Console.WriteLine("========Köket========\n1. Använd köksapparat\n2. Lägg till köksapparat\n3. Lista köksapparater\n4. Ta bort köksapparat\n5. Avsluta");
    Console.Write("Ange val:\n>");
    //nie zapomniec o wyjasnieniu ze tu moze byc tez tryparse - lepszy wybor
    //albo pokazac kod tu w komentarzu
    //try catch w tym miejscu
    string input = Console.ReadLine();
    int choice = int.Parse(input);
    switch (choice)
    {
        case 1:
            Ikea.action();
            break;
        case 2:
            break;
        case 3:
            Ikea.Lista();
            break;
        case 4:
            break;
        case 5:
            Console.WriteLine("Vi ses nästa gången!");
            menu = false;
            break;
        default:
            Console.WriteLine("Fel inmätning. Använd siffror 1 till 5 bara");
            break;
    } 
}







public interface IKitchenAppliance
{
    string Type { get; set; }
    string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    void Use();
}
public class Equipment : IKitchenAppliance
{


    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    public Equipment(string type, string brand, bool isFunctioning)
    {
        this.Type = type;
        this.Brand = brand;
        this.IsFunctioning = isFunctioning;
    }

    public void Use()
    {
        if (IsFunctioning)
        {
            Console.WriteLine($"Du använder {this.Type}.");
        }
        else
        {
            Console.WriteLine($"Tyvärr {this.Type} fungerar inte.");
        }
    }
}

class Kitchen
{
    List<IKitchenAppliance> thing = new List<IKitchenAppliance>();    
    public void AddNewItem(IKitchenAppliance item)
    {
        thing.Add(item);        
    }
    public void Lista()
    {
        foreach (var item in thing)
        {
            Console.WriteLine(item.Type);
        }        
    }
    public void action()
    {
        //tu try parse bo można wyjśc poza listę
        int index = 1;
        Console.WriteLine($"Vilken köksapparat vill du använda? Du har:");
        foreach(var item in thing)
        {
            Console.WriteLine($"{index}. {item.Type}"); 
            index++;
        }
        Console.Write(">");
        int.TryParse(Console.ReadLine(), out int number);
        thing[number - 1].Use();    //eftersom list börjar med index 0 - användaren behöver inte veta om det
    }
}