using UnityEngine;
using UnityEditor;

namespace SleepyApe
{
    [CustomPropertyDrawer(typeof(Reference<,>), true)]
    public class ReferenceDrawer : PropertyDrawer
    {
        private int _useConstant;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _useConstant = property.FindPropertyRelative("_useConstant").boolValue ? 1 : 0;
            var rect = EditorGUI.PrefixLabel(position, label);
            var width = rect.width / 2f - 2.5f;
            var leftRect = new Rect(rect.x, rect.y, width, rect.height);
            var rightRect = new Rect(rect.x + width + 5f, rect.y, width, rect.height);

            _useConstant = EditorGUI.Popup(leftRect, _useConstant, new string[] { "Variable", "Constant" });
            property.FindPropertyRelative("_useConstant").boolValue = _useConstant == 1;

            if (_useConstant == 0)
                EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("_variableValue"), GUIContent.none);
            else
                EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("_constantValue"), GUIContent.none);
        }
    }
}