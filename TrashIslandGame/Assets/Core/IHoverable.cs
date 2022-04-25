using InventoryItems;
using UnityEngine;

namespace Core
{
    public interface IHoverable
    {
        public CostAndName OnHover();
    }
}