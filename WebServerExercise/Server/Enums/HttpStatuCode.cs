using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerExercise.Server.Enums
{
    public enum HttpStatuCode
    {
         OK = 200,
         Moved_Permanently = 301,
         Found = 302,
         MovedTemporaly = 303,
         NotAuthorized = 401,
         NotFound = 404,
         InternalServerError = 500

    }
}
