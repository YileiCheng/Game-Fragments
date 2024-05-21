using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(NPCInteraction))]
public class NPCInteractionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();  // Draws the default inspector

        NPCInteraction script = (NPCInteraction)target;

        if (GUILayout.Button("Add Dialogue Event"))
        {
            script.events.Add(new DialogueEvent());
        }

        if (GUILayout.Button("Add Decision Event"))
        {
            script.events.Add(new Decision());
        }

        if (GUILayout.Button("Add Submit Item Event"))
        {
            script.events.Add(new SubmitItem());
        }

        if (GUILayout.Button("Add Receive Item Event"))
        {
            script.events.Add(new ReceiveItem());
        }

        if (GUILayout.Button("Add Default Event"))
        {
            script.events.Add(new DefaultEvent());
        }

        if (GUILayout.Button("Next Level Event"))
        {
            script.events.Add(new NextLevel());
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}