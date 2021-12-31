using Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyGraph))]
public class MyGraphEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Process"))
        {
            var graph = target as MyGraph;
            var processor = new MyGraphProcessor(graph);
            processor.Run();
        }
    }
}