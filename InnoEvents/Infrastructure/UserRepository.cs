using InnoEvents.DTOs;
using RestSharp;

namespace InnoEvents.Infrastructure
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly RestClient _client;
        public UserRepository(string url)
        {
            _client = new RestClient(url);
        }

        public async Task<User> Get(int id)
        {
            RestRequest request = new RestRequest("users/{id}", Method.Get)
                .AddUrlSegment("id", id);
            var response = await _client.ExecuteAsync<User>(request);
            if (response.IsSuccessful)
            {
                return response.Data;
            }
            
            return null;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
