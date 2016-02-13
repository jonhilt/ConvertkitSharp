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
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToForm(string email, string firstName, long formId)
        {
            var req = RequestEngine.CreateRequest($"forms/{formId}/subscribe", Method.POST, "subscription");

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
        
        /// <summary>
        /// Subscribes a person to multiple <see cref="ConvertKitForm" />s.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="formIds">A list of form ids to subscribe them to.</param>
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToForms(string email, string firstName, IEnumerable<long> formIds)
        {
            long? defaultForm = formIds.FirstOrDefault();
            
            if(defaultForm == null)
            {
                throw new NullReferenceException("You must specify at least one form id to subscribe to.");
            }
            
            var req = RequestEngine.CreateRequest($"forms/{defaultForm}/subscribe", Method.POST, "subscription");
            
            if(formIds.Count() > 1)
            {
                req.AddQueryParameter("forms", string.Join(",", formIds.Where(f => f != defaultForm)));
            }
            
            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
    }
}
