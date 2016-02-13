using Newtonsoft.Json;
using System;

namespace ConvertKitSharp.Entities
{
    /// <summary>
    /// An object representing a ConvertKit tag.
    /// </summary>
    public class ConvertKitTag
    {
        /// <summary>
        /// The date the tag was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The tag's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The tag's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
