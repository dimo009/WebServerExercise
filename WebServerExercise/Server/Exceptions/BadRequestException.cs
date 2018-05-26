using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WebServerExercise.Server.Exceptions
{
    public class BadRequestException:SystemException,ISerializable
    {
        public BadRequestException(string exception)
        {
            this.Exception = exception;
        }

        public string Exception { get;}
    }
}
