using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Server.Contracts;

namespace WebServerExercise.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {

        HttpHeaderCollection HeaderCollection { get; }

        HttpStatusCode StatusCode { get; }

        string StatusMessage { get; }

        string Response { get; }


        void AddHeader(string key, string value);
    }
}
