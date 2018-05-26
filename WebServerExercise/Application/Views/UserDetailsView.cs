using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Application.Views
{
    public class UserDetailsView : IView
    {
        private readonly Model model;

        public UserDetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body><h3>Hello, {model["name"]}!</h3> </br><a href=\"/\">Home</a></body>";
        }
    }
}
