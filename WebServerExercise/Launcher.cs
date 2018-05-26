using System;
using WebServerExercise.Application;
using WebServerExercise.Server;
using WebServerExercise.Server.Contracts;
using WebServerExercise.Server.Routing;
using WebServerExercise.Server.Routing.Contracts;

namespace WebServerExercise
{
    public class Launcher:IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}
