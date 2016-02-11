using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Infrastructure
{
    public class ConvertKitError
    {
        /// <summary>
        /// The type of error, e.g. 'Authorization Failed'.
        /// </summary>
        public string Error { get; set; }
    }
}
