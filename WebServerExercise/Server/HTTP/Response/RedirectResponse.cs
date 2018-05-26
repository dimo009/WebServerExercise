using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl) : base(redirectUrl)
        {
        }
    }
}
