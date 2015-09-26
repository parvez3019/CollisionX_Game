using UnityEngine;
using System.Collections;
using UnityEditor;
using GameSparks.Core;

[CustomEditor(typeof(GameSparksUnity))]
public class GameSparksUnityInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUI.enabled = false;

        GUILayout.BeginHorizontal();
        GUILayout.Label("SDK Version", GUILayout.Width(EditorGUIUtility.labelWidth));
        GUILayout.Label(GS.Version.ToString());
        GUILayout.EndHorizontal();
        GUI.enabled = true;
        base.OnInspectorGUI();

    }
}

