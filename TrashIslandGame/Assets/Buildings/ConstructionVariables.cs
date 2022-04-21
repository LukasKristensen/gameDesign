using UnityEngine;

namespace InventoryItems
{
    [CreateAssetMenu(fileName = "ConstructionVariables", menuName = "ScriptableObjects/ConstructionVariables", order = 1)]
    public class ConstructionVariables : ScriptableObject
    {
        public bool hideSites;
        public void ShowSites()
        {
            hideSites = false;
        }
        public void HideSites()
        {
            hideSites = true;
        }
    }
}