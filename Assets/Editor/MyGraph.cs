using GraphProcessor;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;


[CreateAssetMenu(menuName = "MyGraph", fileName = "MyGraph")]
public class MyGraph : BaseGraph
{
    // ダブルクリックでウィンドウを開く
    [OnOpenAsset(0)]
    public static bool OnBaseGraphOpened(int instanceId, int line)
    {
        var asset = EditorUtility.InstanceIDToObject(instanceId) as MyGraph;

        if (asset == null) return false;

        var window = EditorWindow.GetWindow<MyGraphWindow>();
        window.InitializeGraph(asset);
        return true;
    }
}