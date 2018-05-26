using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode statusCode, IView view) : base(statusCode, view)
        {
        }
    }
}
