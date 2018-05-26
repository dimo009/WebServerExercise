using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Server.Contracts;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {

        private readonly IView view;


        private HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        protected HttpResponse(string redirectUrl)
            :this()
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode statusCode, IView view)
            :this()
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.view = view;
            this.StatusCode = statusCode;
        }



       public HttpHeaderCollection HeaderCollection { get; private set; }

        public HttpStatusCode StatusCode { get; protected set; }

        public string StatusMessage => this.StatusCode.ToString();


        


        public void AddHeader(string field, string value)
        {
            if (!this.HeaderCollection.ContainsKey(field))
            {
                this.HeaderCollection.Add(new HttpHeader(field, value));
            }
           
        }

        public string Response
        {
            get
            {
                var response = new StringBuilder();
                var statusCode = (int)this.StatusCode;

                response.AppendLine($"HTTP/1.1 {statusCode} {this.StatusMessage}");
                response.AppendLine(this.HeaderCollection.ToString());
                response.AppendLine();


                if (statusCode < 300 || statusCode > 399)
                {
                    response.AppendLine(this.view.View());
                }
                return response.ToString();
            }
        }



    }
}
