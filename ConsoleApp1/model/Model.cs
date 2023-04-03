using System.Collections.Generic;

namespace vendingMachine.Model
{
    public class Consumable
    {
        private int currentBalance;

        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        
        public Consumable(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public static List<Consumable> GetConsumables(List<Consumable> consumablesToAdd = null)
        {
            List<Consumable> consumables = new List<Consumable>();
            consumables.Add(new Consumable("Mango Juice", 1500, 10));
            consumables.Add(new Consumable("Lays Chips", 800, 20));
            consumables.Add(new Consumable("Chocorramo", 2000, 5));
            consumables.Add(new Consumable("Isabel Tunna", 4500, 2));
            consumables.Add(new Consumable("Expresso Juan Valdez", 8550, 6));

            if (consumablesToAdd != null)
            {
                consumables.AddRange(consumablesToAdd);
            }

            return consumables;
        }

 
    }
}
