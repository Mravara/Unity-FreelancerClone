using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class EditorExtensions
{
    public enum TabAlignment
    {
        None,
        Left,
        Middle,
        Right,
    }

    public static void TabSet(ref int index, int colCount, System.Action<int> onToolbarButton, params string[] tabs)
    {
        TabSet(ref index, colCount, onToolbarButton, TabAlignment.None, tabs);
    }

    public static void TabSet(ref int index, int colCount, params string[] tabs)
    {
        TabSet(ref index, colCount, null, TabAlignment.None, tabs);
    }

    public static void TabSet(ref int index, int colCount, TabAlignment alignment, params string[] tabs)
    {
        TabSet(ref index, colCount, null, alignment, tabs);
    }

    public static void TabSet(ref int index, int colCount, System.Action<int> onToolbarButton, TabAlignment alignment, params string[] tabs)
    {
        EditorGUILayout.BeginVertical();

        bool opened = false;
        for (int i = 0, j = 0; i < tabs.Length; i++)
        {
            if (colCount != 0 && j == 0)
            {
                opened = true;
                EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
                if (alignment == TabAlignment.Right || alignment == TabAlignment.Middle)
                    GUILayout.FlexibleSpace();
            }

            if (GUILayout.Toggle(index == i, tabs[i], EditorStyles.toolbarButton))
            {
                if (index != i && onToolbarButton != null)
                    onToolbarButton.Invoke(i);
                index = i;
            }

            j++;

            if (colCount != 0 && j == colCount)
            {
                opened = false;
                if (alignment == TabAlignment.Left || alignment == TabAlignment.Middle)
                    GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
                j = 0;
            }
        }

        if (opened)
        {
            if (alignment == TabAlignment.Left || alignment == TabAlignment.Middle)
                GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndVertical();

        if (index > tabs.Length - 1)
            index = 0;
    }

    public static bool DropAreaGUI<T>(SerializedProperty prop) where T : Object
    {
        Event evt = Event.current;
        Rect drop_area = GUILayoutUtility.GetLastRect();

        bool added = false;
        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (!drop_area.Contains(evt.mousePosition))
                    return false;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (evt.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    foreach (Object dragged_object in DragAndDrop.objectReferences)
                    {
                        if (dragged_object is T)
                        {
                            prop.InsertArrayElementAtIndex(prop.arraySize);
                            prop.serializedObject.ApplyModifiedProperties();
                            prop.GetArrayElementAtIndex(prop.arraySize - 1).objectReferenceValue = (T)dragged_object;
                            added = true;
                        }
                    }
                }
                break;
        }
        return added;
    }

    public static bool DropAreaGUI<T>(List<T> list) where T : Object
    {
        Event evt = Event.current;
        Rect drop_area = GUILayoutUtility.GetLastRect();

        bool added = false;
        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (!drop_area.Contains(evt.mousePosition))
                    return false;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (evt.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    foreach (Object dragged_object in DragAndDrop.objectReferences)
                    {
                        if (dragged_object is T)
                        {
                            list.Add(dragged_object as T);
                            added = true;
                        }
                    }
                }
                break;
        }
        return added;
    }

    public static void DrawSeperator()
    {
        EditorGUILayout.Separator();
        Rect sr = EditorGUILayout.GetControlRect(false, 1, GUIStyle.none);
        sr.x -= 5;
        sr.y -= 3;
        EditorGUI.DrawRect(sr, Color.grey.NewAlpha(.35f));
    }

    public static void MultiPropertyField(GUIContent label, SerializedProperty[] properties, GUIContent[] subLabels)
    {
        float defaultLabelWidth = EditorGUIUtility.labelWidth;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel(label);
        EditorGUIUtility.labelWidth = 0f;
        int indentLevel = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        for (int i = 0; i < properties.Length; i++)
        {
            EditorGUILayout.PropertyField(properties[i], GUIContent.none);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUIUtility.labelWidth = defaultLabelWidth;
        EditorGUI.indentLevel = indentLevel;
    }

    public static void DrawSprite(Rect rect, Sprite sprite)
    {
        if (sprite != null)
        {
            if (sprite.texture.height < 16)
                return;

            GUIContent sprContent = new GUIContent();
            sprContent.image = sprite.texture;

            EditorGUI.LabelField(rect, sprContent);
        }
    }
}