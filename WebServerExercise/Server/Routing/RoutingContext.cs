using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Handlers;
using WebServerExercise.Server.Routing.Contracts;

namespace WebServerExercise.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {

        public RoutingContext(RequestHandler requestHandler, IEnumerable<string>args)
        {
            this.Parameters = args;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; set; }
    }
}
