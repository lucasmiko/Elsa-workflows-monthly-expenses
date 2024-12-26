using Elsa.Activities.Console;
using Elsa.Builders;

namespace Elsa_workflows_monthly_expenses
{
    /// <summary>
    /// A basic workflow with just one WriteLine activity.
    /// </summary>
    public class HelloWorld : IWorkflow
    {
        public void Build(IWorkflowBuilder builder) => builder.WriteLine("Hello World!");
    }
}
