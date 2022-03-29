using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    public List<Holdable> currentInventory;
    
    public bool ChangeInventory(List<Item> items)
    {
        var valid = true;
        foreach (var item in items)
        {
            foreach (var invItem in currentInventory.Where(invItem => invItem==item.objectRefrence))
            {
                invItem.amount += item.amount;
                if (invItem.amount<0)
                {
                    valid = false;
                }
            }
        }

        if (!valid)
        {
            foreach (var item in items)
            {
                foreach (var invItem in currentInventory.Where(invItem => invItem==item.objectRefrence))
                {
                    invItem.amount -= item.amount;
                }
            }
        }

        return valid;
    }
}