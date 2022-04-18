using Core;
using InventoryItems;
using PellesAssets;
using UnityEngine;

namespace Buildings
{
    public class ConstructionSite : MonoBehaviour,IInteractable,IHoverable
    {
        private ConstructionManager constructionManager;
        public string uiText;
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

        public CostAndName OnHover()
        {
            CostAndName newCost = new CostAndName();
            newCost.cost = cost;
            newCost.UIText = uiText;
            return newCost;
        }
    }
}
