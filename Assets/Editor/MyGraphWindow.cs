using System.Collections;
using System.Collections.Generic;
using System.IO;
using Editor;
using GraphProcessor;
using UnityEditor;
using UnityEngine;

// UnityのWinodwとして開くことができる
public class MyGraphWindow : BaseGraphWindow
{
    private MyGraphView _myGraphView;

    protected override void InitializeWindow(BaseGraph graph)
    {
        //Assert.IsNotNull(graph);

        titleContent = new GUIContent(ObjectNames.NicifyVariableName("MyGraph"));

        if (graphView == null)
        {
            graphView = new BaseGraphView(this);
            _myGraphView = new MyGraphView(graphView);
            graphView.Add(_myGraphView);
        }

        rootView.Add(graphView);
    }
}