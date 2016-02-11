using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Entities
{
    public class ConvertKitSubscriberList
    {
        /// <summary>
        /// The current page of results.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// The total number of available pages.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// The total number of subscribers.
        /// </summary>
        [JsonProperty("total_subscribers")]
        public int TotalSubscribers { get; set; }

        /// <summary>
        /// An array of subscribers for the current page.
        /// </summary>
        [JsonProperty("subscribers")]
        public IEnumerable<ConvertKitSubscriber> Subscribers { get; set; }
    }
}
