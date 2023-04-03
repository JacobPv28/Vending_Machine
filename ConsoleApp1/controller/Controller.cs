
using System.Security.Cryptography.X509Certificates;

namespace vendingMachine.Controller
{
    public class Consumable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CurrentBalance { get; private set; }

        public Consumable(string Name, int Price, int Quantity)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public static List<Consumable> GetConsumables(List<Consumable> consumablesToAdd = null)
        {
            // Create a list of Consumable objects
            List<Consumable> consumables = new List<Consumable>();
            // Add the existing Consumable objects to the list
            consumables.Add(new Consumable("Mango Juice", 1500, 10));
            consumables.Add(new Consumable("Lays Chips", 800, 20));
            consumables.Add(new Consumable("Chocorramo", 2000, 5));
            consumables.Add(new Consumable("Isabel Tunna", 4500, 2));
            consumables.Add(new Consumable("Expresso Juan Valdez", 8550, 6));

            // If there are any consumables to add, add them to the list
            if (consumablesToAdd != null)
            {
                consumables.AddRange(consumablesToAdd);
            }

            return consumables;
        }

        // Method to search for a consumable by name using LINQ
        public static Consumable SearchConsumableLinq(string name)
        {
            List<Consumable> consumables = GetConsumables();

            var consumable = consumables.FirstOrDefault(c => c.Name == name);

            return consumable;
        }

        internal void ModifyConsumable(string newName, int newPrice, int newQuantity)
        {
            // Update name if new name is not empty
            if (!string.IsNullOrEmpty(newName))
            {
                this.Name = newName;
            }

            // Update price
            this.Price = newPrice;

            // Update quantity
            this.Quantity = newQuantity;

            Name = newName != "" ? newName : Name;
            // Do not update price here
            Quantity = newQuantity;
        }
    }

}







