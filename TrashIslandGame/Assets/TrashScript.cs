using System;
using System.Collections.Generic;
using PellesAssets;
using UnityEngine;

public class TrashScript : Exchangable,IInteractable
{
    public void Interact(FPSController player, Inventory inventory)
    {
        inventory.ChangeInventory(Items);
        Destroy(gameObject);
    }
}



