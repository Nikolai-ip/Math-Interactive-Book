using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(ScrollRect))]
public class ScrollViewEditor : Editor
{
    private float scrollPosition = 1f;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScrollRect scrollRect = (ScrollRect)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Editor Scroll Control", EditorStyles.boldLabel);

        scrollPosition = EditorGUILayout.Slider("Scroll Position", scrollPosition, 0f, 1f);

        if (GUILayout.Button("Apply Scroll Position"))
        {
            scrollRect.verticalNormalizedPosition = scrollPosition;
        }

        if (GUILayout.Button("Scroll to Top"))
        {
            scrollPosition = 1f;
            scrollRect.verticalNormalizedPosition = scrollPosition;
        }

        if (GUILayout.Button("Scroll to Bottom"))
        {
            scrollPosition = 0f;
            scrollRect.verticalNormalizedPosition = scrollPosition;
        }

        // Update the scroll position in real time while dragging the slider
        if (GUI.changed)
        {
            scrollRect.verticalNormalizedPosition = scrollPosition;
        }
    }

}