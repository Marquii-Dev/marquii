using Marquii.Model;

namespace Marquii.Services;

public class PostService
{
    private static List<Post> Posts { get; }
    private static int nextId = 3;

    static PostService()
    {
        Posts = new List<Post>
        {
            new Post {Id = 1, HtmlContent = "<p>Hi</p>"},
            new Post {Id = 2, HtmlContent = "<p>What?</p>"},
        };
    }

    public static Post? Get(long id) => Posts.FirstOrDefault(p => p.Id == id);

    public static void Add(Post post)
    {
        post.Id = nextId++;
        Posts.Add(post);
    }

    public static void Delete(long id)
    {
        var post = Get(id);
        if (post is null)
            return;

        Posts.Remove(post);
    }

    public static void Update(Post post)
    {
        var index = Posts.FindIndex(p => p.Id == post.Id);
        if (index == -1)
            return;

        Posts[index] = post;
    }
}