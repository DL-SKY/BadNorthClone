using DllSky.Components.Services;
using UnityEngine;

namespace DllSky.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(AutoLocatorComponent), true)]
    public class AutoLocatorComponentEditor : Editor
    {
        private SerializedProperty _isDontDestroy;
        private SerializedProperty _isRegisterCurrentComponent;
        private SerializedProperty _component;


        private void OnEnable()
        {
            _isDontDestroy = serializedObject.FindProperty("_isDontDestroy");
            _isRegisterCurrentComponent = serializedObject.FindProperty("_isRegisterCurrentComponent");
            _component = serializedObject.FindProperty("_component");
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _isDontDestroy.boolValue = EditorGUILayout.Toggle("Is Dont Destroy", _isDontDestroy.boolValue);

            if (_isRegisterCurrentComponent.boolValue = EditorGUILayout.Toggle("Register this Component", _isRegisterCurrentComponent.boolValue))
                _component.objectReferenceValue = null;
            else
                _component.objectReferenceValue = EditorGUILayout.ObjectField("Component", _component.objectReferenceValue, typeof(Object), true);

            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            base.OnInspectorGUI();
        }
    }
}
