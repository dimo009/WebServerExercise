using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Application.Views;
using WebServerExercise.Server;
using WebServerExercise.Server.HTTP.Contracts;
using WebServerExercise.Server.HTTP.Response;

namespace WebServerExercise.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }


    }
}
