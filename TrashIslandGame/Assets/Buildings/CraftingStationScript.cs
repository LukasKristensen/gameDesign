using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using PellesAssets;
using UnityEngine;

public class CraftingStationScript : Friendly,IInteractable
{
    
    public void Interact(FPSController player, Inventory inventory)
    {
        print("Crafting");
    }
}
