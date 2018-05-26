using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Application.Views;
using WebServerExercise.Server.HTTP.Contracts;
using WebServerExercise.Server.HTTP.Response;

namespace WebServerExercise.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index() => new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
    }
}
