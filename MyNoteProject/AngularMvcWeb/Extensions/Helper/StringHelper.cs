using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMvcWeb.Extensions.helper
{
    public class StringHelper
    {
        public static string Right(string source, int length)
        {
            if (source.Length > length)
            {
                return source.Substring(source.Length - length, length);
            }
            else
            {
                return source;
            }
        }
        public static string Left(string source, int length)
        {
            if (source.Length > length)
            {
                return source.Substring(0, length);
            }
            else
            {
                return source;
            }
        }
    }
}