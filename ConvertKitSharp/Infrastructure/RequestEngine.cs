using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertKitSharp.Infrastructure
{
    public static class RequestEngine
    {
        /// <summary>
        /// Creates a new <see cref="RestClient"/> configured for use with ConvertKit.
        /// </summary>
        /// <param name="apiKey">The API or secret key for the ConvertKit account.</param>
        /// <returns>The configured <see cref="RestClient"/>.</returns>
        public static RestClient CreateClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new NullReferenceException(nameof(apiKey));
            }

            var client = new RestClient("https://api.convertkit.com/v3/");

            //Set up the JSON.NET deserializer for the RestSharp client
            var deserializer = new JsonNetSerializer();
            client.AddHandler("application/json", deserializer);
            client.AddHandler("text/json", deserializer);

            //Add default access token param to all requests
            client.AddDefaultParameter("api_secret", apiKey, ParameterType.QueryString);

            return client;
        }

        /// <summary>
        /// Creates an <see cref="IRestRequest"/> by setting the method and the necessary Json.Net serializer.
        /// </summary>
        /// <param name="path">The request's path.</param>
        /// <param name="method">The HTTP <see cref="Method"/> to use for the request.</param>
        /// <param name="rootElement">The root element to deserialize. Default is null.</param>
        /// <returns>The prepared <see cref="IRestRequest"/>.</returns>
        /// <remarks>We've created this method to ensure every request uses our custom <see cref="JsonNetSerializer"/>, which ensures 
        /// that each class serializes with the proper <see cref="JsonPropertyAttribute"/></remarks>
        public static IRestRequest CreateRequest(string path, Method method, string rootElement = null)
        {
            return new RestRequest(path, method)
            {
                JsonSerializer = new JsonNetSerializer(),
                RootElement = rootElement
            };
        }

        /// <summary>
        /// Executes a <see cref="IRestRequest"/> and returns a JToken for querying, or throws an exception when the response is invalid. 
        /// Use this method when the expected response is a single line or simple object that doesn't warrant creating its own class.
        /// </summary>
        /// <param name="client">A <see cref="RestClient"/>.</param>
        /// <param name="request">An <see cref="IRestRequest"/>.</param>
        /// <returns>The <see cref="JToken"/> to be queried.</returns>
        public static async Task<JToken> ExecuteRequestAsync(RestClient client, IRestRequest request)
        {
            //Make request
            var response = await client.ExecuteTaskAsync(request);

            //Check for and throw exception when necessary.
            CheckResponseExceptions(response);

            //Get the raw response string
            string respString = Encoding.UTF8.GetString(response.RawBytes);

            //Parse the string if it exists, else parse an empty object. The empty object is expected when
            //Shopify returns a 0-byte body in it's response (e.g. when deleting a charge). 
            return JToken.Parse(string.IsNullOrEmpty(respString) ? "{}" : respString);
        }

        /// <summary>
        /// Executes a <see cref="IRestRequest"/> and returns data of the given type, or throws an exception when the response is invalid.
        /// </summary>
        /// <typeparam name="T">The type of data to be returned.</typeparam>
        /// <param name="client">A <see cref="RestClient"/>.</param>
        /// <param name="request">An <see cref="IRestRequest"/>.</param>
        /// <returns>The data.</returns>
        public static async Task<T> ExecuteRequestAsync<T>(RestClient client, IRestRequest request) where T : new()
        {
            //Make request
            var response = await client.ExecuteTaskAsync<T>(request);

            //Check for and throw exception when necessary.
            CheckResponseExceptions(response);

            return response.Data;
        }

        /// <summary>
        /// Checks an <see cref="IRestResponse" /> for exceptions or invalid responses. Throws an exception when necessary.
        /// </summary>
        /// <param name="response">The response.</param>
        static void CheckResponseExceptions(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            {
                string json = Encoding.UTF8.GetString(response.RawBytes);
                string message = "";
                var error = new ConvertKitError();

                if (string.IsNullOrEmpty(json) == false)
                {
                    var parsed = JToken.Parse(string.IsNullOrEmpty(json) ? "{}" : json);

                    if (parsed.Any(x => x.Path == "errors"))
                    {
                        message = parsed.Value<string>("message");
                        error.Error = parsed.Value<string>("error");
                    }
                    else
                    {
                        error.Error = $"Response did not indicate success. Status: {(int)response.StatusCode} {response.StatusDescription}.";
                        message = json;
                    }
                }
                
                throw new ConvertKitException(response.StatusCode, error, message);
            }

            if (response.ErrorException != null)
            {
                //Checking this second, because Shopify errors sometimes return incomplete objects along with errors, 
                //which cause Json deserialization to throw an exception. Parsing the Shopify error is more important 
                //than throwing this deserialization exception.
                throw response.ErrorException;
            }
        }
    }
}

