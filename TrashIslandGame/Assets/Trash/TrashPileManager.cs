
using System.Collections.Generic;
using UnityEngine;

namespace Trash
{
    public class TrashPileManager : MonoBehaviour
    {
        public List<Transform> RefTrashPileLocations;
        public List<Transform> TrashPileLocations;
        public GameObject TrashPile;
        public int maxAmountOfLiveLocations;
        public int amountOfLiveLocations;
        private void Update()
        {
            if (amountOfLiveLocations<maxAmountOfLiveLocations)
            {
                SpawnPileAtRandomLocation();
            }
        }

        private void SpawnPileAtRandomLocation()
        {
            int randomLocation = Random.Range(0,TrashPileLocations.Count);
            Instantiate(TrashPile, TrashPileLocations[randomLocation].position, Quaternion.identity,TrashPileLocations[randomLocation]);
            RemoveToLocations(TrashPileLocations[randomLocation]);
        }

        public void AddToLocations(Transform location)
        {
            if (!RefTrashPileLocations.Contains(location))
            {
                RefTrashPileLocations.Add(location);
                TrashPileLocations.Add(location);
                return;
            }
            if (TrashPileLocations.Contains(location)) return;
            TrashPileLocations.Add(location);
            amountOfLiveLocations--;
        }
        public void RemoveToLocations(Transform location)
        {
            TrashPileLocations.Remove(location);
            amountOfLiveLocations++;
        }
    }
}
