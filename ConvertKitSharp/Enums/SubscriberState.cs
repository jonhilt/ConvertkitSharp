using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Enums
{
    public enum SubscriberState
    {
        /// <summary>
        /// The subscriber is subscribed.
        /// </summary>
        [JsonProperty("active")]
        Active
    }
}
