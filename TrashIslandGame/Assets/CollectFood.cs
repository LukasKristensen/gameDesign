using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PellesAssets;

public class CollectFood : MonoBehaviour, IInteractable
{
    public int healing = 15; 
    
    // Start is called before the first frame update
   
    public void Interact(FPSController player, Inventory inventory)
    {
        float distancePlayerFruit = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("Distance to fruit: " + distancePlayerFruit);

        if (distancePlayerFruit < 5f)
        {
            Debug.Log("Collected health point");
            player.health += healing;
            Debug.Log("Current Health Points: " + player.health);
            Destroy(gameObject);
        }
    }

}


