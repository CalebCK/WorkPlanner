using System;

namespace WorkPlanner.Extensions.Exceptions
{
    /// <summary>
    /// Exception to handle InValid ModelState
    /// </summary>
    public class InvalidModelException : CustomException
    {
        public InvalidModelException(string message) : base(message)
        {
        }
    }
}
