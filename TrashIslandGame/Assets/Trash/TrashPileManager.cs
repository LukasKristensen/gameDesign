
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
        public List<TrashPile> TrashPiles;
        [SerializeField] private float timer;
        [SerializeField] private float cooldownTime;
        

        private void Update()
        {
            
            if (TrashPiles.Count == 0) { return; }

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
                int randomInt = Random.Range(0,TrashPiles.Count);
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
