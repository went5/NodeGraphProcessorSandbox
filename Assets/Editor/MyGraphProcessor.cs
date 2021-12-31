using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using Unity.Jobs;

namespace Editor
{
    public class MyGraphProcessor : BaseGraphProcessor
    {
        private List<BaseNode> _processList;

        public MyGraphProcessor(BaseGraph graph) : base(graph)
        {
        }

        public override void UpdateComputeOrder()
        {
            _processList = graph.nodes.OrderBy(n => n.computeOrder).ToList();
        }

        public override void Run()
        {
            for (var i = 0; i < _processList.Count; i++)
            {
                _processList[i].OnProcess();
            }

            JobHandle.ScheduleBatchedJobs();
        }
    }
}