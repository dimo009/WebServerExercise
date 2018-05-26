using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Enums;
using WebServerExercise.Server.Handlers;

namespace WebServerExercise.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}
