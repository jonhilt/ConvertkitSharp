using ConvertKitSharp.Converters;
using Newtonsoft.Json;
using System;
using ConvertKitSharp.Enums;

namespace ConvertKitSharp.Entities
{
    /// <summary>
    /// An object representing a ConvertKit form.
    /// </summary>
    public class ConvertKitForm
    {
        /// <summary>
        /// The date the form was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The form's description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The form's JS URL.
        /// </summary>
        [JsonProperty("embed_js")]
        public string EmbedJsUrl { get; set; }  

        /// <summary>
        /// The form's embedded URL.
        /// </summary>
        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        /// <summary>
        /// The form's id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The form's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The form's signup button text.
        /// </summary>
        [JsonProperty("sign_up_button_text")]
        public string SignUpButtonText { get; set; }

        /// <summary>
        /// The form's success message.
        /// </summary>
        [JsonProperty("success_message")]
        public string SuccessMessage { get; set; }

        /// <summary>
        /// The form's title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The form's type. Valid values are: 'embed', 'hosted', ...
        /// </summary>
        [JsonProperty("type"), JsonConverter(typeof(NullableEnumConverter<FormType>))]
        public FormType? Type { get; set; }

        /// <summary>
        /// The form's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
