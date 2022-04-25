using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using Trash;
using UnityEngine;

public class TrashCollecterUpgrade : MonoBehaviour, IHoverable,IInteractable
{
    [SerializeField] private CostAndName costAndName;
    
    public void Interact(FPSController player, Inventory inventory)
    {
        if (!inventory.TryExchange(costAndName)) return;
        TrashCollector[] trashCollectors = FindObjectsOfType<TrashCollector>(includeInactive:true);
        foreach (var trashCollector in trashCollectors)
        {
            trashCollector.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }

    public CostAndName OnHover()
    {
        return costAndName;
    }
}
