using System;
using System.Collections.Generic;

namespace GenTemplate.Application.Common.Exceptions
{
    public class BasicException
    {
        public class BadRequestException : ApplicationException
        {
            public List<string> Errors { get; }
            public BadRequestException(List<string> errors) : base()
            {
                Errors = errors;
            }
        }
        public class UnauthorizedException : ApplicationException
        {
            public UnauthorizedException() : base() { }
            public UnauthorizedException(string message) : base(message) { }
        }
        public class NotFoundException : ApplicationException
        {
            public NotFoundException(string message) : base(message) { }
        }
        public class ConflicException : ApplicationException
        {
            public ConflicException(string message) : base(message) { }
        }
        public class InternalServerErrorException : ApplicationException
        {
            public InternalServerErrorException(string message) : base(message) { }
        }
    }
}
