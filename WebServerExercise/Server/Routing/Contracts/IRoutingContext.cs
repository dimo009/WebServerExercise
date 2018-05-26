using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Handlers;

namespace WebServerExercise.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
