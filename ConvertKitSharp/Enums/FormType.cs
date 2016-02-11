using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Enums
{
    /// <summary>
    /// Represents a type of <see cref="ConvertKitSharp.Entities.ConvertKitForm"/>.
    /// </summary>
    public enum FormType
    {
        [JsonProperty("embed")]
        Embed,

        [JsonProperty("hosted")]
        Hosted
    }
}
