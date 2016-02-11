using ConvertKitSharp.Entities;
using ConvertKitSharp.Infrastructure;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Services
{
    /// <summary>
    /// A service for interacting with <see cref="ConvertKitForm"/>s.
    /// </summary>
    public class ConvertKitFormService : ConvertKitService
    {
        public ConvertKitFormService(string apiKey) : base(apiKey) { }

        /// <summary>
        /// Lists all <see cref="ConvertKitForm"/>s on the user's account.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ConvertKitForm>> ListAsync()
        {
            var req = RequestEngine.CreateRequest("forms", Method.GET, "forms");

            return await RequestEngine.ExecuteRequestAsync<List<ConvertKitForm>>(_RestClient, req);
        }

        /// <summary>
        /// Subscribes a person to a <see cref="ConvertKitForm"/>.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="formId">The id of the form to subscribe them to.</param>
        /// <returns>The new subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToForm(string email, string firstName, long formId)
        {
            var req = RequestEngine.CreateRequest($"forms{formId}/subscribe", Method.POST, "subscription");

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
    }
}
