using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Handlers.Contracts;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.Handlers
{
    public abstract class RequestHandler : IRequestHandler
    {

        private readonly Func<IHttpContext, IHttpResponse> func;


        protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func.Invoke(httpContext);

            httpResponse.AddHeader("Content-Type", "text/html");

            return httpResponse;
        }
    }
}
