using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using Trash;
using UnityEngine;

public class FloatingTrashScript : MonoBehaviour,IHoverable,IInteractable
{
    public CostAndName cost;
    public Transform model;
    public LayerMask layerMask;
    public SphereCollider collider;
    private void Update()
    {
        if (Physics.Raycast(transform.position,Vector3.down,out RaycastHit hit,layerMask))
        {
            model.position = hit.point;
        }
    }

    public CostAndName OnHover()
    {
        return cost;
    }

    public void Interact(FPSController player, Inventory inventory)
    {
        inventory.TryExchange(cost);
        transform.GetComponentInParent<TrashPile>().floatingTrashs.Remove(transform);
        Destroy(gameObject);
    }
}
