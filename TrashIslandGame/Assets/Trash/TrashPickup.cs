using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using Resources = InventoryItems.Resources;

public class TrashPickup : MonoBehaviour,IInteractable
{
    [SerializeField] private Loot loot;
    public void Interact(FPSController player, Inventory inventory)
    {
        inventory.TryExchange(loot);
        Destroy(gameObject);
    }
}
