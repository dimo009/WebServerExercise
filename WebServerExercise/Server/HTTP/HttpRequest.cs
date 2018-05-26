using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServerExercise.Server.Enums;
using WebServerExercise.Server.Exceptions;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        

        public Dictionary<string, string> FormData { get; set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; set; }

        public Dictionary<string, string> QueryParameters { get; set; }

        public HttpRequestMethod RequestMethod { get; set; }

        public string Url { get; set; }

        public Dictionary<string, string> UrlParameters {get;}

        //public object ParseParameters { get; private set; }



        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string[] requestLine = requestLines[0].Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length!=3 || !requestLine[2].ToLower().Equals("http/1.1"))
            {
                throw new BadRequestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());

            this.Url = requestLine[1];

            this.Path = this.Url.Split(new[] { '?','#'},StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);

            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }
        }



        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            

            try
            {
                HttpRequestMethod httpRequestMethod = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), requestMethod);
                return httpRequestMethod;
                
            }
            catch (Exception)
            {

                throw new BadRequestException($"{requestMethod} is not a valid Http Request Method");
            }
            
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.None);

                var header = new HttpHeader(headerArgs[0], headerArgs[1]);

                this.HeaderCollection.Add(header);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid request line");
            }

        }
        private void ParseParameters()
        {
            if (!this.Url.Contains("/"))   //COMMENT changed from / to ?
            {
                return;
            }
            string query = this.Url.Split('/')[1];   //COMMENT changed from / to ?
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');

            foreach (string queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split("=");

                if (queryArgs.Length!=2)
                {
                    continue;
                }

                queryParameters.Add(WebUtility.UrlDecode(queryArgs[0]),WebUtility.UrlDecode(queryArgs[1]));
            }
        }
    }
}
