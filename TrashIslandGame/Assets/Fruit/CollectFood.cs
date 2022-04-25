using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using UnityEngine;
using PellesAssets;

public class CollectFood : MonoBehaviour, IInteractable
{
    public int healing = 15;
    public GameVariables gameVariables;
    public void Interact(FPSController player, Inventory inventory)
    {
        healing = gameVariables.fruitHeal;
        player.health += healing;
        Destroy(gameObject);
    }
}


