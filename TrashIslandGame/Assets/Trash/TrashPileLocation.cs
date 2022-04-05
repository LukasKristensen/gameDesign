using UnityEngine;

namespace Trash
{
    public class TrashPileLocation : MonoBehaviour
    {
        private TrashPileManager trashPileManager;

        private void Start()
        {
            trashPileManager = FindObjectOfType<TrashPileManager>();
            AddToManager();
        }

        public void AddToManager()
        {
            trashPileManager.AddToLocations(transform);
        }
    }
}
