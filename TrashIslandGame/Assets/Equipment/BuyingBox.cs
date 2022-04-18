using System;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;

namespace Equipment
{
    public class BuyingBox : MonoBehaviour,IInteractable,IHoverable
    {
        [SerializeField] private EquippableAsset equippableAsset;
        
        public void Interact(FPSController player, Inventory inventory)
        {
            if (equippableAsset==null)
            {
                Debug.Log("NO ASSET ASSIGNT TO " + gameObject.name);   
                return;
            }

            switch (equippableAsset.type)
            {
                case EquippableType.Hammer:
                    if (player.Hammer != null) return;
                    break;
                case EquippableType.Spear:
                    if (player.Spear != null)
                        if (player.Spear.teir >= equippableAsset.teir)
                            return;
                    break;
                case EquippableType.Shield:
                    break;
                case EquippableType.Sword:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (!inventory.TryExchange(equippableAsset.cost)) return;
            player.Equip(equippableAsset);
            Destroy(gameObject);
        }


        public CostAndName OnHover()
        {
            CostAndName newCost = new CostAndName();
            newCost.cost = equippableAsset.cost;
            newCost.UIText = "Upgrade "+equippableAsset.type+"?";
            return newCost;
        }
    }
}
