using System;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : Exchangable,IInteractable
{
    public void Interact(Inventory inventory)
    {
        inventory.ChangeInventory(Items);
        Destroy(gameObject);
    }
}



