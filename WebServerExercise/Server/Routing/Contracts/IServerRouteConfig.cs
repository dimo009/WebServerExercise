using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Enums;

namespace WebServerExercise.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}
