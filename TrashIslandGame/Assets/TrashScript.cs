using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : Exchangable,IInteractable
{
    
    
    void Start()
    {
        
    }

    

    public void Interact(Inventory inventory)
    {
        inventory.ChangeInventory(Items);
        Destroy(gameObject);
    }
}

public abstract class Exchangable : MonoBehaviour
{
    public List<Item> Items;
}
[Serializable]
public class Item
{
    public Holdable objectRefrence;
    public int amount;
}
