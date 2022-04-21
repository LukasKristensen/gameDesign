using System;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEditor;
using UnityEngine;

namespace Buildings
{
    public class ConstructionSite : MonoBehaviour,IInteractable,IHoverable
    {
        public string uiText;
        [SerializeField] private Cost cost;
        [SerializeField] private GameObject Building;
        
        public void Interact(FPSController player, Inventory inventory)
        {
            if (Building == null)
            {
                Debug.Log("NO BUILDING SET IN " + gameObject.name);
                return;
            }
            if (!inventory.TryExchange(cost)) return;
            Building.SetActive(true);
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
}
