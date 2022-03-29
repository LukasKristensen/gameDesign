using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Stations
{
    [CreateAssetMenu(fileName = "newBuilding", menuName = "ScriptableObjects/Building", order = 2)]
    public class Building : ScriptableObject
    {
        public string name;
        public List<Item> cost;
        public GameObject prefab;
    }
}