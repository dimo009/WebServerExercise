using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Routing.Contracts;

namespace WebServerExercise.Server.Contracts
{
    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}
