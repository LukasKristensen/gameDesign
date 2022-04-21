using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using Trash;
using UnityEngine;

public class TrashCollector : MonoBehaviour,IInteractable,IHoverable
{
    [SerializeField] private GameObject model;
    [SerializeField] private Cost cost;
    [SerializeField] private string uiText = "Build TrashCollector?";
    [SerializeField] private Material boughtMat;
    public bool bought;

    public void Interact(FPSController player, Inventory inventory)
    {
        if (!inventory.TryExchange(cost)) return;
        bought = true;
        foreach (var renderer in model.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.material = boughtMat;
        }
        GetComponent<MeshRenderer>().material = boughtMat;
        GetComponentInParent<TrashPile>().Collected();
    }

    public CostAndName OnHover()
    {
        CostAndName newCost = new CostAndName();
        newCost.cost = cost;
        newCost.UIText = uiText;
        return newCost;
    }
}
