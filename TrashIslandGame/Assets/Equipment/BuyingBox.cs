using System;
using InventoryItems;
using PellesAssets;
using UnityEngine;

namespace Equipment
{
    public class BuyingBox : MonoBehaviour,IInteractable
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
        }

        
    }
}
