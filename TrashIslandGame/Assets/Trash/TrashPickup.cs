using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using Resources = InventoryItems.Resources;

public class TrashPickup : MonoBehaviour,IInteractable,IHoverable
{
    [SerializeField] private CostAndName loot;
    public void Interact(FPSController player, Inventory inventory)
    {
        inventory.TryExchange(loot.cost);
        Destroy(gameObject);
    }

    public CostAndName OnHover()
    {
        return loot;
    }
}
