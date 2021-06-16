using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SleepyApe
{
    [CustomPropertyDrawer(typeof(Setting), true)]
    public class SettingDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Only execute when object reference value is null
            if (property.objectReferenceValue == null)
                AssignSettingAsset(property);

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = true;
        }

        private void AssignSettingAsset(SerializedProperty property)
        {
            // Get all type inherit from Setting
            var settingType = typeof(Setting);
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(type => type.GetTypes())
                .Where(
                    type => !type.IsInterface
                    && !type.IsAbstract
                    && type != settingType
                    && settingType.IsAssignableFrom(type)
                ).ToList();

            foreach (var type in types)
            {
                // if current type is same as target
                // TODO: Find better way to find compare type from property.type
                if ($"PPtr<${type.Name}>" == property.type)
                    property.objectReferenceValue = CreateOrSelect(type);
            }
        }

        private Setting CreateOrSelect(Type type)
        {
            Setting settingAsset = null;
            var guids = AssetDatabase.FindAssets($"t:{type}");

            foreach (var guid in guids)
            {
                settingAsset = AssetDatabase.LoadAssetAtPath<Setting>(AssetDatabase.GUIDToAssetPath(guid));
                break;
            }

            if (settingAsset == null)
            {
                var asset = ScriptableObject.CreateInstance(type);
                // TODO: Handle setting for custom asset path
                AssetDatabase.CreateAsset(asset, $"Assets/{type.ToString()}.asset");
                settingAsset = (Setting)asset;
            }

            return settingAsset;
        }
    }
}