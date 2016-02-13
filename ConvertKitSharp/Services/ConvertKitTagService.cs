using ConvertKitSharp.Entities;
using ConvertKitSharp.Infrastructure;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertKitSharp.Services
{
    /// <summary>
    /// A service for interacting with <see cref="ConvertKitTag"/>s.
    /// </summary>
    public class ConvertKitTagService : ConvertKitService
    {
        public ConvertKitTagService(string apiKey) : base(apiKey) { }

        /// <summary>
        /// Lists all <see cref="ConvertKitTag"/>s on the user's account.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ConvertKitTag>> ListAsync()
        {
            var req = RequestEngine.CreateRequest("tags", Method.GET, "tags");

            return await RequestEngine.ExecuteRequestAsync<List<ConvertKitTag>>(_RestClient, req);
        }

        /// <summary>
        /// Subscribes a person to a <see cref="ConvertKitTag"/>.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="tagId">The id of the Tag to subscribe them to.</param>
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToTag(string email, string firstName, long tagId)
        {
            var req = RequestEngine.CreateRequest($"tags/{tagId}/subscribe", Method.POST, "subscription");

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
        
        /// <summary>
        /// Subscribes a person to multiple <see cref="ConvertKitTag" />s.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="tagIds">A list of Tag ids to subscribe them to.</param>
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToTags(string email, string firstName, IEnumerable<long> tagIds)
        {
            long? defaultTag = tagIds.FirstOrDefault();
            
            if(defaultTag == null)
            {
                throw new NullReferenceException("You must specify at least one tag id to subscribe to.");
            }
            
            var req = RequestEngine.CreateRequest($"Tags/{defaultTag}/subscribe", Method.POST, "subscription");
            
            if(tagIds.Count() > 1)
            {
                req.AddQueryParameter("tags", string.Join(",", tagIds.Where(f => f != defaultTag)));
            }
            
            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
    }
}
