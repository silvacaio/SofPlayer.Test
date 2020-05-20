using System.Net.Http;
using System.Threading.Tasks;

namespace SoftPlayer.Domain.Core.Handler
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient _client;

        public HttpClientHandler(HttpClient client)
        {
            _client = client;
        }

        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return PostAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<string> GetStringAsync(string url)
        {
            return await _client.GetStringAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}
