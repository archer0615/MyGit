using System;

namespace AngularProject.Extensions.Exceptions
{
    public class EmptyCellException : Exception
    {
        public EmptyCellException(string msg)
        : base(msg)
        {
        }
    }
}