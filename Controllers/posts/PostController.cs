using Marquii.Model;
using Marquii.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marquii.Controllers.posts;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    [HttpGet("{id:long}")]
    public ActionResult<Post> GetPostById(long id)
    {
        var post = PostService.Get(id);
        if (post is null)
            return NotFound();

        return post;
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {
        PostService.Add(post);
        return CreatedAtAction(nameof(Create), new {id = post.Id}, post);
    }

    [HttpPut("{id:long}")]
    public IActionResult Put(long id, Post post)
    {
        if (id != post.Id)
            return BadRequest();

        var existingPost = PostService.Get(id);
        if (existingPost is null)
            return NotFound();

        PostService.Update(post);

        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id)
    {
        var post = PostService.Get(id);
        if (post is null)
            return NotFound();

        PostService.Delete(id);

        return NoContent();
    }
}