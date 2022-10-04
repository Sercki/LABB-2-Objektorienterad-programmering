
using System;
using static System.Collections.Specialized.BitVector32;

Equipment cooker = new Equipment("cooker", "Daewoo", true);
Equipment dishwasher = new Equipment("dishwasher", "Bosh", true);
Equipment fridge = new Equipment("fridge", "Cylinda", true);
Equipment damaged = new Equipment("damaged", "not working", false);
List<IKitchenAppliance> thing = new List<IKitchenAppliance>();
actions reaction = new actions();
reaction.AddNewItem(fridge);
reaction.AddNewItem(damaged);
reaction.AddNewItem(dishwasher);
reaction.AddNewItem(cooker);
reaction.Lista();








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
            Console.WriteLine($"{this.Type} is turned on.");
        }
        else
        {
            Console.WriteLine($"{this.Type} won't start. It is damaged.");
        }
    }    
}
class actions
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
}