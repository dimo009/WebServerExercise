using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WebServerExercise.Application.Views;
using WebServerExercise.Server.Contracts;
using WebServerExercise.Server.Handlers.Contracts;
using WebServerExercise.Server.HTTP.Contracts;
using WebServerExercise.Server.HTTP.Response;
using WebServerExercise.Server.Routing.Contracts;

namespace WebServerExercise.Server.Handlers
{
    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            foreach (KeyValuePair<string, IRoutingContext> kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = kvp.Key;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(httpContext);
            }

            return new ViewResponse(HttpStatusCode.NotFound, new NotFoundView());       //(Enums.HttpStatusCode.NotFound, new NotFoundView());
        }
    }


}
