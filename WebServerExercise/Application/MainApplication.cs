using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Application.Controllers;
using WebServerExercise.Server.Contracts;
using WebServerExercise.Server.Handlers;
using WebServerExercise.Server.Routing.Contracts;

namespace WebServerExercise.Application
{
    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-z]+)}", new GetHandler(httpContext => new UserController().Details(httpContext.Request.UrlParameters["name"])));

            appRouteConfig.AddRoute(
                "/register", new PostHandler(httpContext => new UserController().RegisterPost(httpContext.Request.FormData["name"])));

            appRouteConfig.AddRoute(
                "/register", new GetHandler(httpContext => new UserController().RegisterGet()));

            appRouteConfig.AddRoute("/", new GetHandler(httpContext => new HomeController().Index()));
        }
    }
}
