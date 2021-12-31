using GraphProcessor;

namespace WentTool
{
    [System.Serializable, NodeMenuItem("Went/Float")]
    public class Float2Node : BaseNode
    {
        [Output("Out")] public float output;

        [Input("In")] public float input;

        public override string name => "Float";

        protected override void Process()
        {
            output = input;
        }
    }
}