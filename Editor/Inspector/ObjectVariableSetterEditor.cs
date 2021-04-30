using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace SleepyApe
{
    [CustomEditor(typeof(ObjectVariableSetter))]
    public class ObjectVariableSetterEditor : Editor
    {
        private SerializedProperty _variableProperty;
        private ReorderableList _variableList;

        private void OnEnable()
        {
            _variableProperty = serializedObject.FindProperty("_variables");
            _variableList = new ReorderableList(serializedObject, _variableProperty, false, false, true, true);
            _variableList.drawElementCallback = DrawVariableElement;
        }

        private void DrawVariableElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            var property = _variableProperty.GetArrayElementAtIndex(index);
            var width = rect.width / 2f - 2.5f;
            var leftRect = new Rect(rect.x, rect.y, width, rect.height);
            var rightRect = new Rect(rect.x + width + 5f, rect.y, width, rect.height);

            EditorGUI.PropertyField(leftRect, property.FindPropertyRelative("objectVariable"), GUIContent.none);
            EditorGUI.PropertyField(rightRect, property.FindPropertyRelative("sceneObject"), GUIContent.none);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _variableList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}