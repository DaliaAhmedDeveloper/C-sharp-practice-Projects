namespace App.Controller;
using App.Helpers;
using CommentService = App.Services.Comment;
using CommentModel = App.Models.Comment;
class Comment : IController
{
    
  private static Comment? _instance;
    private static readonly object _lock = new object();
     public static Comment instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Comment();
                }
            }
        }
        return _instance;
    }
    private Comment() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await CommentService.Get();
    }
    public async Task ShowAll( bool download = false ) // show all records
    {
        string json = await GetAll();
        // convert json to objects with case sensitive option 
        List<CommentModel> comments = JsonHelper.DeserializeJsonList<CommentModel>(json) ?? new();

        if (comments != null)
        {
            foreach (CommentModel comment in comments)
            {
                Console.WriteLine($"Id is {comment.Id}");
                Console.WriteLine($"Name is {comment.Name}");
                Console.WriteLine($"Email is {comment.Email}");
                Console.WriteLine($"Body is {comment.Body}");
                Console.WriteLine($"PostId is  {comment.PostId}");
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
        return await CommentService.Find(id);
    }
    
     public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        CommentModel comment = JsonHelper.DeserializeJson<CommentModel>(json) ?? new();
       
        if (comment != null)
        {
                Console.WriteLine($"Id is {comment.Id}");
                Console.WriteLine($"Name is {comment.Name}");
                Console.WriteLine($"Email is {comment.Email}");
                Console.WriteLine($"Body is {comment.Body}");
                Console.WriteLine($"PostId is  {comment.PostId}");
                Console.WriteLine("---------------");
        }
        else
        {
             Console.WriteLine("No Results !");
        }

    }
    // extra Methos
}