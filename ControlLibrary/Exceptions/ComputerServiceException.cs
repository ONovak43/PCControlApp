using System;

namespace ControlLibrary.Exceptions
{
    [Serializable]
    public class ComputerServiceException : System.Exception
    {
        public ComputerServiceException()
        { }

        public ComputerServiceException(string msg)
            : base(msg)
        { }

        public ComputerServiceException(string msg, System.Exception inner)
            : base(msg, inner)
        { }
    }
}
