using System;
using System.Collections.Generic;

namespace PCWebApp.Services.Exceptions
{
    public class InvalidDataException : Exception{
        internal List<string> _errors;
        
        public IReadOnlyCollection<string> Errors => _errors;

        public InvalidDataException()
        {}

        public InvalidDataException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public InvalidDataException(string message) : base(message)
        { }

        public InvalidDataException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}