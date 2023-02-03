using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(TargetFinderIndicator))]
public class TargetFinderIndicatorCustomEditor : Editor
{
    #region SerializedProperties
    private SerializedProperty targetIndicatorUIProperty;
    private SerializedProperty targetObjectProperty;
    private SerializedProperty cameraProperty;
    private SerializedProperty alwaysShowCursorProperty;

    bool GameObjectsSection = true;
    bool OptionsSection = false;
    #endregion

    #region OnEnable()
    private void OnEnable()
    {
        targetIndicatorUIProperty = serializedObject.FindProperty("targetIndicatorUI");
        targetObjectProperty = serializedObject.FindProperty("targetObject");
        cameraProperty = serializedObject.FindProperty("Camera");
        alwaysShowCursorProperty = serializedObject.FindProperty("alwaysShowCursor");
    }
    #endregion

    #region OnInspectorGUI()
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GameObjectsSection = EditorGUILayout.Foldout(GameObjectsSection, "GameObjects");
        if (GameObjectsSection)
        {
            EditorGUILayout.PropertyField(targetIndicatorUIProperty);
            EditorGUILayout.PropertyField(targetObjectProperty);
            EditorGUILayout.PropertyField(cameraProperty);
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        OptionsSection = EditorGUILayout.Foldout(OptionsSection, "Options");
        if (OptionsSection)
        {
            EditorGUILayout.PropertyField(alwaysShowCursorProperty);
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}
#endif
