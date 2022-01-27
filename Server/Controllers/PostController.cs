using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBoost.Server.Data;
using MyBoost.Shared.Data;

namespace MyBoost.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        //public List<Post> PostsList { get; set; } = new List<Post>
        //{
        //    new Post { Url = "new-url", Title = "txtTitle", Description = "txtDescription", Content = "txtContent"},
        //    new Post { Url = "first-post", Title = "txtTitle2", Description = "txtDescription2", Content = "txtContent2"}
        //};

        public PostController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllPosts()
        {
            //var postList = _context.PostsList.ToList();
            //var objPost = _mapper.Map<PostDTO>(postList);
            //return Ok(objPost);
            return Ok(_context.PostsList);
        }

        [HttpGet("{url}")]
        public ActionResult<Post> GetSinglePost(string url)
        {
            var post = _context.PostsList.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            //var objPost = _mapper.Map<PostDTO>(post);
            if (post == null)
            {
                return NotFound("This post does not exist");
            }
            //return Ok(objPost);
            return Ok(post);
        }

        //Create new post
        [HttpPost]
        public async Task<ActionResult<Post>> CreateNewPost(Post request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
