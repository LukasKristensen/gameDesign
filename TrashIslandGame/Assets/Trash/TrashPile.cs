using System;
using System.Collections.Generic;
using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;
using Random = UnityEngine.Random;
using Resources = InventoryItems.Resources;

namespace Trash
{
    public class TrashPile : MonoBehaviour,IInteractable,IHoverable
    {
        [SerializeField] private int teir = 0;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject floatingTrashPrefab;
        [SerializeField] private float floatingTrashSpeed;
        [SerializeField] private Transform floatingTRashSpawnPoint;
        [SerializeField] private int amountOfTrash;
        
        public bool full;
        
        [SerializeField] private CostAndName loot;

        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform floatingTrashGoal;
        [SerializeField] private EnemyManagerAsset  enemyManagerAsset;
        
        [SerializeField] private List<GameObject> teirs;
        public List<Transform> floatingTrashs;
        [SerializeField] private TrashCollector trashCollector;
        public bool collected;
        [SerializeField] private bool spawnTrash;
        [SerializeField] private SphereCollider _sphereCollider;
        
        private void Start()
        {
            TeirChange(teir);
        }

        private void Update()
        {
            
            MoveFloatingTrash();
        }

        private void MoveFloatingTrash()
        {
            List<Transform> toRemove = new List<Transform>();
            foreach (var t  in floatingTrashs)
            {
                Vector3 nextStep = floatingTrashGoal.position - t.position;
                if (nextStep.magnitude <1)
                {
                    if (trashCollector.bought) continue;
                    
                    if (teir < 4)
                    {
                        teir++;
                        TeirChange(teir);
                    }
                    else
                    {
                        int randomNumber = Random.Range(1,101);
                        GameObject toSpawn = randomNumber < enemyManagerAsset.basicEnemyChance * 100
                            ? enemyManagerAsset.basicEnemyPrefab
                            : enemyManagerAsset.shooterEnemyPrefab;
                        Instantiate(toSpawn, spawnPoint.position, Quaternion.identity, transform.parent);
                    }
                    toRemove.Add(t);
                }
                else
                {
                    t.position+= nextStep.normalized * floatingTrashSpeed * Time.deltaTime;
                }
            }
            if (spawnTrash)
            {
                floatingTrashs.Add(Instantiate(floatingTrashPrefab,floatingTRashSpawnPoint.position, Quaternion.identity,transform).transform);
                amountOfTrash++;
                spawnTrash = false;
            }

            if (toRemove.Count == 0) return;
            foreach (var t in toRemove)
            {
                floatingTrashs.Remove(t);
                Destroy(t.gameObject);
            }
            
        }
        public void TeirChange(int teir)
        {
            foreach (var go in teirs)
            {
                go.SetActive(false);
            }
            teirs[teir].SetActive(true);
            _sphereCollider.enabled = teir != 0;
        }
        public void Interact(FPSController player, Inventory inventory)
        {
            teir--;
            inventory.TryExchange(loot);
            TeirChange(teir);
        }
        public void SpawnFloatingTrash()
        {
            spawnTrash = true;
        }

        public void Collected()
        {
            collected = true;
        }

        public CostAndName OnHover()
        {
            return loot;
        }
    }
}
