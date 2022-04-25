using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using Trash;
using UnityEngine;

public class TrashCollector : MonoBehaviour, IHoverable,IInteractable
{
    [SerializeField] private GameObject model;
    [SerializeField] private Material boughtMat;
    [SerializeField] private CostAndName costAndName;
    
    public bool bought;

    public void Interact(FPSController player, Inventory inventory)
    {
        if (!inventory.TryExchange(costAndName)) return;
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
        return costAndName;
    }
}
