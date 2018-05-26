using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}
