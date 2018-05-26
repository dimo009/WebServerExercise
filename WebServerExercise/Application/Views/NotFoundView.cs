using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Application.Views
{
    public class NotFoundView : IView
    {
        public string View()
        {
            return "<body><center><h1>404 Not Found :(</h1></br><a href=\"/\">Home</a></center></body>";
        }
    }
}
