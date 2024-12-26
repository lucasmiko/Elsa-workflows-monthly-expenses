using System.Net;
using Elsa.Activities.Http;
using Elsa.Builders;

namespace HelloWorldHttp
{
    public class HelloWorldHttp : IWorkflow
    {
        /// <summary>
        /// A workflow that is triggered when HTTP requests are made to /hello-world and writes a response.
        /// </summary>
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .HttpEndpoint("/")
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World!</h1>", "text/html");
        }
    }
}
