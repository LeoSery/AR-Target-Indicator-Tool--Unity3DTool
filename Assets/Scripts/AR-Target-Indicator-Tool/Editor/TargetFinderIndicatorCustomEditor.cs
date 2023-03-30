////////////////////////////////////////////////////////////////////////////////////
// AR-Target-Indicator-Tool -- Léo Séry
// ####
// Script modifying the Unity3D GUI to display in a more organized way the Script component of the tool.
// Script by Léo Séry - 08/02/2023
// ####
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(TargetFinderIndicator))]
public class TargetFinderIndicatorCustomEditor : Editor
{
    #region SerializedProperties
    private SerializedProperty targetSpritesProperty;
    private SerializedProperty targetIndicatorUIProperty;
    private SerializedProperty targetObjectProperty;
    private SerializedProperty cameraProperty;
    private SerializedProperty alwaysShowCursorProperty;
    private SerializedProperty showHelpBoxProperty;
    private SerializedProperty helpObjectProperty;
    private SerializedProperty helpTextProperty;

    bool GameObjectsSection = true;
    bool OptionsSection = false;
    #endregion

    #region OnEnable()
    private void OnEnable()
    {
        targetSpritesProperty = serializedObject.FindProperty("targetSprites");
        targetIndicatorUIProperty = serializedObject.FindProperty("targetIndicatorUI");
        targetObjectProperty = serializedObject.FindProperty("targetObject");
        cameraProperty = serializedObject.FindProperty("Camera");
        alwaysShowCursorProperty = serializedObject.FindProperty("alwaysShowCursor");
        showHelpBoxProperty = serializedObject.FindProperty("showHelpBox");
        helpObjectProperty = serializedObject.FindProperty("helpBoxObject");
        helpTextProperty = serializedObject.FindProperty("helpBoxText");
    }
    #endregion

    #region OnInspectorGUI()
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GameObjectsSection = EditorGUILayout.Foldout(GameObjectsSection, "GameObjects");
        if (GameObjectsSection)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(targetIndicatorUIProperty);
            EditorGUILayout.PropertyField(targetObjectProperty);
            EditorGUILayout.PropertyField(cameraProperty);
            EditorGUILayout.PropertyField(targetSpritesProperty);
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        OptionsSection = EditorGUILayout.Foldout(OptionsSection, "Options");
        if (OptionsSection)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(alwaysShowCursorProperty);
            EditorGUILayout.PropertyField(showHelpBoxProperty);
            if (showHelpBoxProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(helpObjectProperty);
                EditorGUILayout.PropertyField(helpTextProperty);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}
#endif
