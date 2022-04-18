using System;

namespace InventoryItems
{
    [Serializable]
    public class Cost : Resources { }
    public class CostAndName
    {
        public Cost cost;
        public string UIText;
    }
}