
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


namespace Trash
{
    public class TrashPileManager : MonoBehaviour
    {
        public TrashPile[] TrashPiles;
        [SerializeField] private float timer;
        [SerializeField] private float cooldownTime;
        [SerializeField] private float minCooldownTime;
        [SerializeField] private float maxCooldownTime;
        [SerializeField] private float TimeToMax;
        [SerializeField] private float gameTime;
        
        public GameVariables gameVariables;
        private void Start()
        {
            minCooldownTime = gameVariables.BaseTrashSpawnRate;
            maxCooldownTime = gameVariables.MaxTrashSpawnRate;
            TimeToMax = gameVariables.TimeToMaxSpawnRate;
            cooldownTime = minCooldownTime;
            gameTime = 0;

            TrashPiles = FindObjectsOfType<TrashPile>();
        }

        private void Update()
        {
            if (TrashPiles.Length == 0) { return; }

            gameTime = gameTime < TimeToMax ? gameTime + Time.deltaTime : TimeToMax;
            cooldownTime = Mathf.Lerp(minCooldownTime, maxCooldownTime, gameTime/TimeToMax);
            bool check = true;
            foreach (var trashPile in TrashPiles.Where(trashPile => !trashPile.collected))
            {
                check = false;
            }

            if (check)
            {
                SceneManager.LoadScene("Scenes/WinGame");
            }
            if (timer < 0 )
            {
                int randomInt = Random.Range(0,TrashPiles.Length);
                if (!TrashPiles[randomInt].full)
                {
                    TrashPiles[randomInt].SpawnFloatingTrash();
                    timer = cooldownTime;
                }
            }
            timer -= Time.deltaTime;
        }
    }
}
