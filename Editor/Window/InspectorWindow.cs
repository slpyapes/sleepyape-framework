using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SleepyApe
{
    public class InspectorWindow : EditorWindow
    {
        private int _selectedComponent;

        [MenuItem("Window/SleepyApe/Inspector")]
        private static void ShowWindow()
        {
            var window = GetWindow<InspectorWindow>("Inspector");
            window.Show();
        }

        private void OnGUI()
        {
            var activeGameObject = Selection.activeGameObject;

            if (activeGameObject == null)
                return;

            var components = activeGameObject.GetComponents<Component>();
            var guiContents = new List<GUIContent>();

            if (_selectedComponent >= components.Length)
                _selectedComponent = 0;

            foreach (var component in components)
            {
                var objectContent = EditorGUIUtility.ObjectContent(component, component.GetType());

                var guiContent = new GUIContent
                {
                    image = objectContent.image,
                    tooltip = component.GetType().ToString()
                };

                guiContents.Add(guiContent);
            }

            var selectedComponent = components[_selectedComponent];
            var editor = Editor.CreateEditor(selectedComponent);

            _selectedComponent = GUILayout.Toolbar(_selectedComponent, guiContents.ToArray(), GUILayout.Height(20f));
            editor.OnInspectorGUI();
        }
    }
}