using System.Collections;
using System.Collections.Generic;
using InventoryItems;
using UnityEngine;
using PellesAssets;

public class CollectFood : MonoBehaviour, IInteractable
{
    public int healing = 15; 
    
    // Start is called before the first frame update
   
    public void Interact(FPSController player, Inventory inventory)
    {
        float distancePlayerFruit = Vector3.Distance(player.transform.position, transform.position);

        if (distancePlayerFruit < 5f)
        {
            player.health += healing;
            Destroy(gameObject);
        }
    }

}


