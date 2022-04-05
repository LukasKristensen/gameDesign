using InventoryItems;
using PellesAssets;
using UnityEngine;

namespace Buildings
{
    public class ConstructionSite : MonoBehaviour,IInteractable
    {
        private ConstructionManager constructionManager;
        [SerializeField] private Cost cost;
        [SerializeField] private GameObject Building;
        private void Start()
        {
            constructionManager = FindObjectOfType<ConstructionManager>();
            constructionManager?.AddSite(gameObject);
        
        }

        public void Interact(FPSController player, Inventory inventory)
        {
            if (Building == null)
            {
                Debug.Log("NO BUILDING SET IN " + gameObject.name);
                return;
            }
            if (!inventory.TryExchange(cost)) return;
            Building.SetActive(true);
            constructionManager?.RemoveSite(gameObject);
            Destroy(gameObject);
        }
    }
}
