using System;
using System.Collections.Generic;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using Resources = InventoryItems.Resources;

namespace Trash
{
    public class TrashPile : MonoBehaviour,IInteractable
    {
        [SerializeField] private int teir = 1;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Loot loot;
        private float timer;

        [SerializeField] private float SpawnCooldown = 2;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private List<GameObject> teirs;
    
        private void Update()
        {
            if (timer < 0)
            {
                NextTeir();
            }
            timer -= Time.deltaTime;
        }

        private void NextTeir()
        {
        
            TeirChange(teir);
            switch (teir)
            {   
                case >=4:
                    timer = SpawnCooldown*4;
                    Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity);
                    break;
                case >=3:
                    teir++;
                    timer = SpawnCooldown;
                    break;
                case >=1:
                    teir++;
                    timer = SpawnCooldown*2;
                    break;
                default:
                    teir++;
                    break;
            }
        }

        public void TeirChange(int teir)
        {
            foreach (var go in teirs)
            {
                //go.SetActive(false);
            }
            teirs[teir].SetActive(true);
        }
        public void Interact(FPSController player, Inventory inventory)
        {
            if (teir<=0)
            {
                return;
            }
            teir--;
            inventory.TryExchange(loot);
            TeirChange(teir);
            if (teir <= 0)
            {
                CleanUpPile();
            }
        }

        private void CleanUpPile()
        {
            gameObject.GetComponentInParent<TrashPileLocation>().AddToManager();
            Destroy(gameObject);
        }
    }
}
