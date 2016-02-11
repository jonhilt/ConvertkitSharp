using ConvertKitSharp.Infrastructure;
using RestSharp;
using System;

namespace ConvertKitSharp.Services
{
    public abstract class ConvertKitService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConvertKitService" />.
        /// </summary>
        /// <param name="apiKey">The API or secret key for the ConvertKit account.</param>
        protected ConvertKitService(string apiKey)
        {
            _RestClient = RequestEngine.CreateClient(apiKey);
        }
        
        protected RestClient _RestClient { get; set; }
    }
}

