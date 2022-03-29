using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PellesAssets;

public class CollectFood : MonoBehaviour, IInteractable
{
    public GameObject player;
    public FPSController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health: "+playerScript.health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(Inventory inventory)
    {
        float distancePlayerFruit = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("Distance to fruit: " + distancePlayerFruit);

        if (distancePlayerFruit < 5f)
        {
            Debug.Log("Collected health point");
            playerScript.health += 15;
            Debug.Log("Current Health Points: " + playerScript.health);
            Destroy(gameObject);
        }
    }

}


