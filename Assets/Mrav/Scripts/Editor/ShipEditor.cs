using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Ship))]
public class ShipEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Ship ship = (Ship)target;
        if(GUILayout.Button("Cache Weapons"))
        {
            ship.CacheWeapons();
            EditorUtility.SetDirty(ship);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}