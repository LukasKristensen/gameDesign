using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;

public class TrashCollecterUpgrade : MonoBehaviour, IHoverable,IInteractable
{
    [SerializeField] private List<GameObject> trashCollectors;
    [SerializeField] private CostAndName costAndName;
    
    public void Interact(FPSController player, Inventory inventory)
    {
        if (!inventory.TryExchange(costAndName.cost)) return;

        foreach (var trashCollector in trashCollectors)
        {
            trashCollector.SetActive(true);
        }
        Destroy(gameObject);
    }

    public CostAndName OnHover()
    {
        return costAndName;
    }
}
