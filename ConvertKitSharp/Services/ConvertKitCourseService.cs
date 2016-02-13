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
    /// A service for interacting with <see cref="ConvertKitCourse"/>s.
    /// </summary>
    public class ConvertKitCourseService : ConvertKitService
    {
        public ConvertKitCourseService(string apiKey) : base(apiKey) { }

        /// <summary>
        /// Lists all <see cref="ConvertKitCourse"/>s on the user's account.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ConvertKitCourse>> ListAsync()
        {
            var req = RequestEngine.CreateRequest("courses", Method.GET, "courses");

            return await RequestEngine.ExecuteRequestAsync<List<ConvertKitCourse>>(_RestClient, req);
        }

        /// <summary>
        /// Subscribes a person to a <see cref="ConvertKitCourse"/>.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="courseId">The id of the Course to subscribe them to.</param>
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToCourse(string email, string firstName, long courseId)
        {
            var req = RequestEngine.CreateRequest($"courses/{courseId}/subscribe", Method.POST, "subscription");

            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
        
        /// <summary>
        /// Subscribes a person to multiple <see cref="ConvertKitCourse" />s.
        /// </summary>
        /// <param name="email">The subscriber's email address.</param>
        /// <param name="firstName">The subscriber's first name.</param>
        /// <param name="courseIds">A list of Course ids to subscribe them to.</param>
        /// <returns>The subscriber.</returns>
        public async Task<ConvertKitSubscriber> SubscribeToCourses(string email, string firstName, IEnumerable<long> courseIds)
        {
            long? defaultCourse = courseIds.FirstOrDefault();
            
            if(defaultCourse == null)
            {
                throw new NullReferenceException("You must specify at least one course id to subscribe to.");
            }
            
            var req = RequestEngine.CreateRequest($"Courses/{defaultCourse}/subscribe", Method.POST, "subscription");
            
            if(courseIds.Count() > 1)
            {
                req.AddQueryParameter("courses", string.Join(",", courseIds.Where(f => f != defaultCourse)));
            }
            
            return await RequestEngine.ExecuteRequestAsync<ConvertKitSubscriber>(_RestClient, req);
        }
    }
}
