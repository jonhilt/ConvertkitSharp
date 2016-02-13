using Newtonsoft.Json;
using System;

namespace ConvertKitSharp.Entities
{
    /// <summary>
    /// An object representing a ConvertKit course.
    /// </summary>
    public class ConvertKitCourse
    {
        /// <summary>
        /// The date the course was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The course's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The course's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
