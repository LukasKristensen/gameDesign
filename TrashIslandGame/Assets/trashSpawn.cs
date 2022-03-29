using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PellesAssets;


public class trashSpawn : MonoBehaviour,IInteractable
{
    public int teir = 0;
    public GameObject enemyPrefab;

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
            go.SetActive(false);
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
        TeirChange(teir);
    }
}
