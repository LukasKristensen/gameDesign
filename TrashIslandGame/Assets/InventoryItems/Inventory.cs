using UnityEngine;

namespace InventoryItems
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
    public class Inventory : ScriptableObject
    {
        public int health;
        public int Metal;
        public int Plastic;

        public bool TryExchange(CostAndName cost)
        {
            if (cost.loot)
            {
                Metal += cost.cost.Metal;
                Plastic += cost.cost.Plastic;
                return true;
            }
            else
            {
                if (Metal - cost.cost.Metal < 0 || Plastic - cost.cost.Plastic < 0)
                {
                    return false;
                }
                Metal -= cost.cost.Metal;
                Plastic -= cost.cost.Plastic;
                return true;
            }
        }
    }
}