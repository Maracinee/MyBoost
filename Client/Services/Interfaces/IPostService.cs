using MyBoost.Shared.Data;

namespace MyBoost.Client.Services.Interfaces
{
    interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostByUrl(string url);
        Task<Post> CreateNewPost(Post request);
    }
}
