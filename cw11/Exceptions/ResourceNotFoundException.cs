using System;

namespace cw11.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string? message) : base(message)
        {
        }
    }
}