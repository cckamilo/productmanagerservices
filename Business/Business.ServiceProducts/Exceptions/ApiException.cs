using System;
using System.Globalization;

namespace Business.ServiceProducts.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] _args) : base(string.Format(CultureInfo.CurrentCulture, message, _args)) { }


    }
}
