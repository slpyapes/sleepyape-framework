using System;
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
            var types = EditorHelper.FindDerivedTypes(typeof(Setting));

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
            // Find asset with filter
            var guids = AssetDatabase.FindAssets($"t:{type}");
            var sleepyApeSetting = SleepyApeSetting.GetInstance();

            Setting settingAsset = null;

            foreach (var guid in guids)
            {
                // Set asset if found
                settingAsset = AssetDatabase.LoadAssetAtPath<Setting>(AssetDatabase.GUIDToAssetPath(guid));
                break;
            }

            if (settingAsset == null)
            {
                var fileDirectory = $"Assets/{sleepyApeSetting.DefaultSettingDirectory}";
                // Create directory
                EditorHelper.CreateDirectoryIfNotExists(fileDirectory);

                var asset = ScriptableObject.CreateInstance(type);
                AssetDatabase.CreateAsset(asset, $"{fileDirectory}{type.ToString()}.asset");
                settingAsset = (Setting)asset;
            }

            return settingAsset;
        }
    }
}