using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStationScript : Friendly,IInteractable
{
    
    public void Interact(Inventory inventory)
    {
        print("Crafting");
    }
}
