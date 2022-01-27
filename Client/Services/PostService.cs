using MyBoost.Client.Services.Interfaces;
using MyBoost.Shared.Data;
using System.Net.Http.Json;

namespace MyBoost.Client.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _http;

        public PostService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Post> CreateNewPost(Post request)
        {
            var result = await _http.PostAsJsonAsync("api/Post", request);
            return await result.Content.ReadFromJsonAsync<Post>();
        }

        public async Task<Post> GetPostByUrl(string url)
        {
            //return PostsList.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));

            //var post = await _http.GetFromJsonAsync<Post>($"api/Post/{url}");
            //return post;

            var result = await _http.GetAsync($"api/Post/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Post { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Post>();
            }
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _http.GetFromJsonAsync<List<Post>>("api/Post");
        }
    }
}
