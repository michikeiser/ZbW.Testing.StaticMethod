namespace ZbW.Testing.StaticMethod
{
    using System;

    internal class CouldNotMoveFileException : Exception
    {
        public CouldNotMoveFileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}