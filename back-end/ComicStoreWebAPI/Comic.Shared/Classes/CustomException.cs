using System;

namespace ComicStore.Shared.Class
{
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception inner) : base(message, inner) { }
        protected CustomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    public class LessThanZeroException : CustomException
    {
        public LessThanZeroException(string message) : base(message) { }
    }

    public class EqualZeroException : CustomException
    {
        public EqualZeroException(string message = "Não é possível atribuir uma valor igual a 0") : base(message) { }
    }
}
