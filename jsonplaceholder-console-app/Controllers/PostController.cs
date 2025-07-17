namespace App.Controller;
using App.Helpers;
using PostService = App.Services.Post;
using PostModel = App.Models.Post;
using CommentModel = App.Models.Comment;

class Post : IController
{
    private static Post? _instance;
    private static readonly object _lock = new object();
    public static Post instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Post();
                }
            }
        }
        return _instance;
    }
    private Post() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await PostService.Get();
    }
    public async Task ShowAll(bool download = false) // show all records
    {
        string json = await GetAll();
        if (download == true)
        {
            FileBuilder.Download(json);
        }
        // convert json to objects with case sensitive option 
        List<PostModel> posts = JsonHelper.DeserializeJsonList<PostModel>(json) ?? new();

        if (posts != null)
        {
            foreach (PostModel post in posts)
            {
                Console.WriteLine($"Id is {post.Id}");
                Console.WriteLine($"Title is {post.Title}");
                Console.WriteLine($"Body is {post.Body}");
                Console.WriteLine($"User Id is {post.UserId}");
                Console.WriteLine("---------------");
            }
        }
        else
        {
            Console.WriteLine("No Results !");
        }
    }
    public async Task<string> Find(int id) // fetch one record by id
    {
        return await PostService.Find(id);
    }

    public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        PostModel post = JsonHelper.DeserializeJson<PostModel>(json) ?? new();

        if (post != null)
        {
            Console.WriteLine($"Id is {post.Id}");
            Console.WriteLine($"Title is {post.Title}");
            Console.WriteLine($"Body is {post.Body}");
            Console.WriteLine($"User Id is {post.UserId}");
            Console.WriteLine("---------------");
        }
        else
        {
            Console.WriteLine("No Results !");
        }

    }
    // extra Methos
    
    public async Task Comments(int id)
    {

        string json = await PostService.FindByRelation("posts", id);
        List<CommentModel> comments = JsonHelper.DeserializeJsonList<CommentModel>(json) ?? new();

        if (comments != null)
        {
            foreach (CommentModel comment in comments)
            {
                Console.WriteLine($"Id : {comment.Id}");
                Console.WriteLine($"Name : {comment.Name}");
                Console.WriteLine($"Email : {comment.Email}");
                Console.WriteLine($"Body : {comment.Body}");
                Console.WriteLine($"Post Id : {comment.PostId}");
                Console.WriteLine("--------------");
            }
        }
        else
        {
            Console.WriteLine("No Results !");
        }
            
    }
}