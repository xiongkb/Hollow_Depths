using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PlayerHealth))]
public class PlayerHealthEditor : Editor
{
    public string[] options = new string[] { "Health Icons", "Health Bar"};
    SerializedProperty icons;
    SerializedProperty bar;

    private void OnEnable()
    {
        icons = serializedObject.FindProperty("HealthIcons");
        bar = serializedObject.FindProperty("HealthBar");
    }

    public override void OnInspectorGUI()
    {
        PlayerHealth health = (PlayerHealth)target;

        health.maxHealth = EditorGUILayout.IntField("Max Health", health.maxHealth);
        health.currentHealth = EditorGUILayout.IntField("Current Health", health.currentHealth);

        EditorGUILayout.Space(20);

        health.index = EditorGUILayout.Popup("Display Type", health.index, options);

        if (health.index == 0)
        {
            health.useHealthBar = false;
            EditorGUILayout.PropertyField(icons);
        }
        else
        {
            health.useHealthBar = true;
            EditorGUILayout.PropertyField(bar);
        }
        serializedObject.ApplyModifiedProperties();
       

        

    }






}
