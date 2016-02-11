using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Infrastructure
{
    public class ConvertKitException : ApplicationException
    {
        #region Public properties

        public HttpStatusCode HttpStatusCode { get; set; }

        public ConvertKitError ConvertKitError { get; set; }

        #endregion

        #region Constructors

        public ConvertKitException() { }

        public ConvertKitException(string message) : base(message) { }

        public ConvertKitException(HttpStatusCode httpStatusCode, ConvertKitError convertKitError, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ConvertKitError = convertKitError;
        }

        #endregion
    }
}

