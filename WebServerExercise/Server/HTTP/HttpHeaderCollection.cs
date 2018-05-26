using System;
using System.Collections.Generic;
using System.Text;
using WebServerExercise.Server.HTTP.Contracts;

namespace WebServerExercise.Server.HTTP
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (!this.headers.ContainsKey(header.Key))
            {
                this.headers.Add(header.Key, header);
            }
            else
            {
                throw new InvalidOperationException("The collections contains this key");
            }
            
        }

        public bool ContainsKey(string key)
        {
            if (this.headers.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public HttpHeader GetHeader(string key)
        {
            HttpHeader header = null;

            if (this.ContainsKey(key))
            {
                header = this.headers[key];
            }
            return header;
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers.Values);   //it was this.headers
        }
    }
}
