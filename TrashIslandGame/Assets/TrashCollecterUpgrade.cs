using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;

public class TrashCollecterUpgrade : MonoBehaviour,IInteractable,IHoverable
{
    [SerializeField] private Cost cost;
    [SerializeField] private string uiText = "Upgrade Building Tools?";
    [SerializeField] private List<GameObject> trashCollectors;
    
    
    public void Interact(FPSController player, Inventory inventory)
    {
        if (!inventory.TryExchange(cost)) return;

        foreach (var trashCollector in trashCollectors)
        {
            trashCollector.SetActive(true);
        }
        Destroy(gameObject);
    }

    public CostAndName OnHover()
    {
        CostAndName newCost = new CostAndName();
        newCost.cost = cost;
        newCost.UIText = uiText;
        return newCost;
    }
}
