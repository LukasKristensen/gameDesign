using System;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEditor;
using UnityEngine;

namespace Buildings
{
    public class ConstructionSite : MonoBehaviour, IHoverable,IInteractable
    {
        
        [SerializeField] private GameObject Building;
        [SerializeField] private bool justInteract;
        [SerializeField] private CostAndName costAndName;
        public void Interact(FPSController player, Inventory inventory)
        {
            if (Building == null)
            {
                Debug.Log("NO BUILDING SET IN " + gameObject.name);
                return;
            }
            if (!inventory.TryExchange(costAndName)) return;
            Building.SetActive(true);
            Destroy(gameObject);
        }

        public  CostAndName OnHover()
        {
            return costAndName;
        }

    }
}
