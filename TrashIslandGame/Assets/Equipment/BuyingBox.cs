using System;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using UnityEngine.UIElements;

namespace Equipment
{
    public class BuyingBox : MonoBehaviour,IInteractable,IHoverable
    {
        [SerializeField] private EquippableAsset equippableAsset;
        [SerializeField] private EquippableController eController;
        [SerializeField] private EquippableType type;
        [SerializeField] private int teir;
        [SerializeField] private Cost cost;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private BoxCollider _collider;
        
        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _collider = GetComponent<BoxCollider>();
            
            
            GameObject player = GameObject.Find("Player");
            switch (type)
            {
                case EquippableType.Spear:
                    eController = player.GetComponent<FPSController>().spear;
                    break;
                case EquippableType.Shield:
                    eController = player.GetComponent<FPSController>().shield;
                    break;
                case EquippableType.Sword:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Update()
        {
            if (eController.currentTeir == teir-1)
            {
                _renderer.enabled = true;
                _collider.enabled = true;
            }
            else
            {
                _renderer.enabled = false;
                _collider.enabled = false;
            }
        }

        public void Interact(FPSController player, Inventory inventory)
        {
            if (!inventory.TryExchange(cost)) return;

            eController.Upgrade();
            
            Destroy(gameObject);
        }


        public CostAndName OnHover()
        {
            CostAndName newCost = new CostAndName();
            newCost.cost = cost;
            newCost.UIText = "Upgrade "+type+"?";
            return newCost;
        }
    }
}
