using ConvertKitSharp.Entities;
using ConvertKitSharp.Infrastructure;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Services
{
    /// <summary>
    /// A service for interacting with <see cref="ConvertKitSubscriber"/>s.
    /// </summary>
    public class ConvertKitSubscriberService : ConvertKitService
    {
        /// <summary>
        /// Creates a new instance of a <see cref="ConvertKitSubscriberService"/>.
        /// </summary>
        public ConvertKitSubscriberService(string apiKey) : base(apiKey) { }

        /// <summary>
        /// Lists subscribers for the ConvertKit account.
        /// </summary>
        /// <param name="page">The page of subscribers to get.</param>
        /// <returns>The <see cref="ConvertKitSubscriberList"/>.</returns>
        public async Task<ConvertKitSubscriberList> ListAsync(int page = 1)
        {
            var req = RequestEngine.CreateRequest("subscribers", Method.GET);

            if (page > 1) req.AddParameter("page", page);

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriberList>(_RestClient, req);
        }

        /// <summary>
        /// Updates a <see cref="ConvertKitSubscriber"/>.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <returns>The updated subscriber.</returns>
        public async Task<ConvertKitSubscriber> UpdateAsync(long subscriberId, ConvertKitSubscriber subscriber)
        {
            var req = RequestEngine.CreateRequest($"subscribers/{subscriberId}", Method.PUT, "subscriber");

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }

        /// <summary>
        /// Unsubscribes a current <see cref="ConvertKitSubscriber"/>.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        public async Task UnsubscribeAsync(string email)
        {
            var req = RequestEngine.CreateRequest("subscribers", Method.PUT);

            await RequestEngine.ExecuteRequestAsync(_RestClient, req);
        }
    }
}
