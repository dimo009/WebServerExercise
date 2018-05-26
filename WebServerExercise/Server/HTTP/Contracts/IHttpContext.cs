using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerExercise.Server.HTTP.Contracts
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
