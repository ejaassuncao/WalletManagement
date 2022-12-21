using System;

namespace Domain.Commons.Validate
{
    public class ExceptionDomainValidation:Exception
    {
        public ExceptionDomainValidation(string error):base(error)
        {

        }

        public static void When(bool hasError, string message)
        {
            if (hasError) 
                throw new ExceptionDomainValidation(message);
        }

    }
}
