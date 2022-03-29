using System;
using System.Collections.Generic;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(Inventory))]
    public class InventoryEditor : UnityEditor.Editor
    {
        private List<Holdable> _holdables;
        private Inventory _inventory;
        private void OnEnable()
        {
            _inventory = (Inventory)serializedObject.targetObject;

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            foreach (var i in _inventory.currentInventory)
            {
                EditorGUILayout.TextField(i.name);
                EditorGUILayout.IntField(i.amount);
            }
        }
    }
}
