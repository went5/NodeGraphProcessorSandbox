using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;

namespace WentTool
{
    [System.Serializable, NodeMenuItem("Went/AddNode")]
    public class AddNode1 : BaseNode
    {
        [Input(name = "A")] public float input;
        [Input(name = "B")] public float input2;
        [Output(name = "Out")] public float output;

        public override string name => "AddNode";

        protected override void Process()
        {
            output = input + input2;
        }
    }
}