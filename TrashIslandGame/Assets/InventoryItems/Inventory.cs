using UnityEngine;

namespace InventoryItems
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
    public class Inventory : ScriptableObject
    {
        public int health;
        public int Metal;
        public int Plastic;

        public bool TryExchange(Cost cost)
        {
            if (Metal - cost.Metal < 0 || Plastic - cost.Plastic < 0)
            {
                return false;
            }
            Metal -= cost.Metal;
            Plastic -= cost.Plastic;
            return true;
        }
        public void TryExchange(Loot loot)
        {
            Metal += loot.Metal;
            Plastic += loot.Plastic;
        }
    }
}