Kitchen Ikea = new Kitchen();
Ikea.StartingList();
//może tu coś w stylu zaladowane sprzety kuchenne, kliknij by przejsc do menu a po console.readline dac console clear?

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
            Ikea.Action();
            break;
        case 2:
            Ikea.AddNewItem();
            break;
        case 3:
            Ikea.Lista();
            break;
        case 4:
            Ikea.RemoveItem();
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
        public void StartingList()
    {
        Equipment cooker = new Equipment("cooker", "Daewoo", true);
        Equipment fridge = new Equipment("fridge", "Cylinda", true);
        Equipment damaged = new Equipment("damaged", "not working", false);       
        Equipment dishwasher = new Equipment("dishwasher", "Bosh", true);
        thing.Add(cooker);
        thing.Add(dishwasher);
        thing.Add(fridge);
        thing.Add(damaged);
    }
    public void AddNewItem()
    {
        Console.Write("\nAnge typ av köksapparaten:\n>");
        string type = Console.ReadLine();
        Console.Write("\nAnge namn av köksapparaten:\n>");
        string brand = Console.ReadLine();
        Console.Write("\nAnge om köksapparaten fungerar (j/n):\n>");
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
                Console.WriteLine("Fel inmätning. Använd j för \"ja\" eller n för \"nej\". Försök igen:");
                Console.Write(">");
            }
        }
        Equipment nowy = new Equipment(type, brand, isFunctioning);
        this.thing.Add(nowy);
        Console.WriteLine("Tillagd!");
    }
    public void Lista()
    {
        foreach (var item in thing)
        {
            Console.WriteLine(item.Type);
        }
    }
    public void Action()
    {
        //tu try catch bo można wyjśc poza listę
        int index = 1;
        Console.WriteLine($"Vilken köksapparat vill du använda? Du har:");
        foreach (var item in thing)
        {
            Console.WriteLine($"{index}. {item.Type}");
            index++;
        }
        Console.Write(">");
        int.TryParse(Console.ReadLine(), out int number);
        thing[number - 1].Use();    //eftersom list börjar med index 0 - användaren behöver inte veta om det
    }
    public void RemoveItem()
    {
        Console.WriteLine("Vilken köksapparat vill du ta bort?");
        Console.Write(">");
        int.TryParse(Console.ReadLine(), out int deleteAt);
        thing.RemoveAt(deleteAt - 1);  //- 1 eftersom lista börjar med index 0 och inte 1. Så om användaren ska radera 1 objekt på listan, han skriver 1. I resultaten obiekt på index 0 raderas(första objekt i listan).
    }
}