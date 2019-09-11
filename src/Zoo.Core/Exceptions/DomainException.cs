using System;

namespace Zoo.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message){}
    }
}