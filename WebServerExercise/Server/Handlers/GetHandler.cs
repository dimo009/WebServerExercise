using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.Handlers
{
    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}
