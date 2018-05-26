using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Application.Views
{
    public class HomeIndexView : IView
    {
        public string View()
        {
            return "<body><h1>Welcome</h1></body>";
        }
    }
}
