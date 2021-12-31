using GraphProcessor;
using NodeGraphProcessor.Examples;
using Status = UnityEngine.UIElements.DropdownMenuAction.Status;

namespace Editor
{
    public class MyGraphView : ToolbarView
    {
        private ConditionalProcessor _conditionalProcessor;

        public MyGraphView(BaseGraphView graphView) : base(graphView)
        {
            //graphView.computeOrderUpdated += _conditionalProcessor.UpdateComputeOrder;
        }

        protected override void AddButtons()
        {
            AddButton("Run", OnRun, left: false);
            AddButton("Step", OnStep, left:false);

            // ツールバービューの便利なトグルボタンを使える
            base.AddButtons();

            RemoveButton("Show Processor", true);
        }

        void OnRun()
        {
            var graph = graphView.graph as MyGraph;
            // basegraphprocessorのrunでもいい
            var processor = new MyGraphProcessor(graph);
            processor.Run();
        }

        void OnStep()
        {
            if (_conditionalProcessor == null)
            {
                _conditionalProcessor = new ConditionalProcessor(graphView.graph);
            }

            BaseNodeView view;

            if (_conditionalProcessor.currentGraphExecution != null)
            {
                // Unhighlight the last executed node
                view = graphView.nodeViews.Find(
                    v => v.nodeTarget == _conditionalProcessor.currentGraphExecution.Current);
                view.UnHighlight();
            }

            _conditionalProcessor.Step();

            // Display debug infos, currentGraphExecution is modified in the Step() function above
            if (_conditionalProcessor.currentGraphExecution != null)
            {
                view = graphView.nodeViews.Find(
                    v => v.nodeTarget == _conditionalProcessor.currentGraphExecution.Current);
                view.Highlight();
            }
        }
    }
}