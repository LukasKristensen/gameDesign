using System;

namespace InventoryItems
{
    [Serializable]
    public class Cost : Resources { }
    [Serializable]
    public class CostAndName
    {
        public Cost cost;
        public string UIText;
        public bool justInteract;
    }
}