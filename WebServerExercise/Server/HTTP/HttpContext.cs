using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.HTTP
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestStr)
        {
            this.request = new HttpRequest(requestStr);
        }
        public IHttpRequest Request => this.request;
    }
}
