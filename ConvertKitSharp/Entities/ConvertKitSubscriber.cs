using ConvertKitSharp.Converters;
using ConvertKitSharp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Entities
{
    /// <summary>
    /// Represents a subscriber in ConvertKit.
    /// </summary>
    public class ConvertKitSubscriber
    {
        /// <summary>
        /// The subscriber's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The subscriber's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The subscriber's email address.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The current state of the subscriber.
        /// </summary>
        [JsonProperty("state"), JsonConverter(typeof(NullableEnumConverter<SubscriberState>))]
        public SubscriberState? State { get; set; }

        /// <summary>
        /// The date the subscriber was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
