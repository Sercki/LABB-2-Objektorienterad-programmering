﻿Kitchen Ikea = new Kitchen();
Ikea.StartingList();
Ikea.MainMenu();

public interface IKitchenAppliance
{
    string Type { get; set; }
    string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    void Use();
}
/// <summary>
/// Skapade en abstract class Rum som class köket ärver ifrån. Kanske i framtiden kan man skapa flera rum?
/// </summary>
abstract class Rum    
{
    public abstract void MainMenu();
    public abstract void AddNewItem();
    public abstract void Lista();
    public abstract void Action();
    public abstract void RemoveItem();
}

/// <summary>
/// Class equipment ärver ifån interface IKitchenAppliance
/// </summary>
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

class Kitchen :Rum
{
    List<IKitchenAppliance> thing = new List<IKitchenAppliance>();
    public override void MainMenu()
    {
        bool menu = true;
        while (menu)
        {
            try
            {
                Console.WriteLine("\n========Köket========\n1. Använd köksapparat\n2. Lägg till köksapparat\n3. Lista köksapparater\n4. Ta bort köksapparat\n5. Avsluta");
                Console.Write("Ange val:\n>");
                string input = Console.ReadLine();  //använder inte TryParse här för att visa typkonvertering
                int choice = int.Parse(input);
                switch (choice)
                {
                    case 1:
                        Action();
                        break;
                    case 2:
                        AddNewItem();
                        break;
                    case 3:
                        Lista();
                        break;
                    case 4:
                        RemoveItem();
                        break;
                    case 5:
                        Console.WriteLine("Vi ses nästa gången!");
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Fel inmätning. Använd siffror 1 till 5.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Fel inmätning. Använd bara heltal!");
            }
        }
    }
    public void StartingList()
    {
        Equipment cooker = new Equipment("spis", "Daewoo", true);
        Equipment fridge = new Equipment("kyl", "Cylinda", true);
        Equipment damaged = new Equipment("trasig", "Antik", false);
        Equipment dishwasher = new Equipment("diskmaskin", "Bosh", true);
        thing.Add(cooker);
        thing.Add(dishwasher);
        thing.Add(fridge);
        thing.Add(damaged);
    }
    public override void AddNewItem()
    {
        Console.Write("Ange typ av köksapparaten:\n>");
        string type = Console.ReadLine();
        Console.Write("Ange namn av köksapparaten:\n>");
        string brand = Console.ReadLine();
        Console.Write("Ange om köksapparaten fungerar (j/n):\n>");
        bool isFunctioning;
        while (true)
        {
            string choice = Console.ReadLine();
            if (choice == "j" || choice == "J")
            {
                isFunctioning = true;
                break;
            }
            else if (choice == "n" || choice == "N")
            {
                isFunctioning = false;
                break;
            }
            else
            {
                Console.Write("Fel inmätning. Använd j för \"ja\" eller n för \"nej\". Försök igen:\n>");
            }
        }
        Equipment nowy = new Equipment(type, brand, isFunctioning);
        this.thing.Add(nowy);
        Console.WriteLine("Tillagd!");
    }
    public override void Lista()
    {
        if (thing.Count == 0)
        {
            Console.WriteLine("Där finns inga köksapparater i köket!");
        }
        else
        {
            foreach (var item in thing)
            {
                Console.WriteLine(item.Type);
            }
        }
    }
    public override void Action()
    {
        int index = 1;
        int number = 0;
        bool check = true;
        Console.WriteLine($"Vilken köksapparat vill du använda? Du har:");
        foreach (var item in thing)
        {
            Console.WriteLine($"{index}. {item.Type}");
            index++;
        }
        Console.Write(">");
        while (check)
        {
            try
            {               //här använder jag try catch + Parse för att visa andra metoden än TryParse.
                number = int.Parse(Console.ReadLine());
                if (number < 1 || number > thing.Count)
                {
                    Console.WriteLine($"Fel siffra. Välj mellan 1 och {thing.Count}!");
                }
                else
                {
                    check = false;
                }
            }
            catch
            {
                Console.WriteLine("Fel inmätning. Använd bara heltal.");
            }
        }
        thing[number - 1].Use();    //eftersom list börjar med index 0 - användaren behöver inte veta om det
    }
    public override void RemoveItem()
    {
        if (thing.Count == 0)
        {
            Console.WriteLine("Du tog bort alla köksapparater!");
        }
        else
        {
            int deleteAt = 0;
            bool check = true;
            Console.Write("Vilken köksapparat vill du ta bort?\n>");
            while (check)
            {
                int.TryParse(Console.ReadLine(), out deleteAt); //här löste jag problemet med fel inmätning genom while loop och TryParse
                if (deleteAt < 1 || deleteAt > thing.Count)
                {
                    Console.WriteLine($"Fel inmätning. Välj mellan 1 och {thing.Count}!");
                }
                else
                {
                    check = false;
                }
            }
            thing.RemoveAt(deleteAt - 1);  //- 1 eftersom lista börjar med index 0 och inte 1. Så om användaren ska radera 1 objekt på listan, han skriver 1. I resultaten obiekt på index 0 raderas(första objekt i listan).
        }
    }    
}