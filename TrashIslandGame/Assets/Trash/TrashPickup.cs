using System.Collections;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using Resources = InventoryItems.Resources;

public class TrashPickup : MonoBehaviour,IInteractable,IHoverable
{
    [SerializeField] private CostAndName loot;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private AudioSource _audioSource;
    
    public void Interact(FPSController player, Inventory inventory)
    {
        inventory.TryExchange(loot);
        _renderer.enabled = false;
        _audioSource.Play();
        Destroy(gameObject,4);
    }

    public CostAndName OnHover()
    {
        return loot;
    }
}
