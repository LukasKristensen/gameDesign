using Core;
using InventoryItems;
using UnityEngine;

namespace Equipment
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/EquippableAsset", order = 5)]
    public class EquippableAsset : ScriptableObject
    {
        public GameObject prefab;
        public Cost cost;
        public EquippableType type;
        public int teir;
        [HideInInspector]public Equippable instant;
        public void Holster()
        {
            instant.OnHolster();
            instant.gameObject.SetActive(false);
        }
        public void Holster(GameObject previousTeir)
        {
            instant.OnHolster();
            Destroy(previousTeir);
        }
        public void Draw(Transform player){
            if (instant== null)
                instant = Instantiate(prefab, player).GetComponent<Equippable>();
            instant.gameObject.SetActive(true);
            instant.OnDraw();
        }
    }
}
