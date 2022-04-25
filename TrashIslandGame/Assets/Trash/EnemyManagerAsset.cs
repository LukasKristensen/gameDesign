using Core;
using InventoryItems;
using UnityEngine;

namespace Trash
{
    [CreateAssetMenu(fileName = "EnemyManagerAsset", menuName = "ScriptableObjects/EnemyManagerAsset", order = 6)]
    public class EnemyManagerAsset : ScriptableObject
    {
        public GameObject basicEnemyPrefab;
        public float basicEnemyChance = 0.75f;
        public GameObject shooterEnemyPrefab;
        public float shooterEnemyChance = 0.25f;
    }
}