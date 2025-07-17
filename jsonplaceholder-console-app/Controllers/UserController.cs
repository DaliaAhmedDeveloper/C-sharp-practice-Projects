namespace App.Controller;

using App.Helpers;
using UserService = App.Services.User;
using PostService = App.Services.Post;
using AlbumService = App.Services.Album;
using TodoService = App.Services.ToDo;

using UserModel = App.Models.User;
using PostModel = App.Models.Post;
using AlbumModel = App.Models.Album;
using TodoModel = App.Models.ToDo;
class User : IController
{
    private static User? _instance;
    private static readonly object _lock = new object();
     public static User instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new User();
                }
            }
        }
        return _instance;
    }
    private User() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await UserService.Get();
    }
    public async Task ShowAll( bool download = false ) // show all records
    {
        string json = await GetAll();
        if (download == true)
        {
            FileBuilder.Download(json);
        }
        // convert json to objects with case sensitive option 
        List<UserModel> users = JsonHelper.DeserializeJsonList<UserModel>(json) ?? new();

        if (users != null)
        {
            foreach (UserModel user in users)
            {
                Console.WriteLine($"Id is {user.Id}");
                Console.WriteLine($"Name is {user.Name}");
                Console.WriteLine($"Email is {user.Email}");
                Console.WriteLine($"Phone is {user.Phone}");
                Console.WriteLine($"Website is  {user.Website}");
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
        return await UserService.Find(id);
    }

    public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        UserModel user = JsonHelper.DeserializeJson<UserModel>(json) ?? new();

        if (user != null)
        {
            Console.WriteLine($"Id is {user.Id}");
            Console.WriteLine($"Name is {user.Name}");
            Console.WriteLine($"Email is {user.Email}");
            Console.WriteLine($"Phone is {user.Phone}");
            Console.WriteLine($"Website is  {user.Website}");
            Console.WriteLine("---------------");
        }
        else
        {
            Console.WriteLine("No Results !");
        }

    }
    // extra Methos
    public async Task<bool> Auth(string email)
    {
        List<UserModel>? users = JsonHelper.DeserializeJsonList<UserModel>(await GetAll());
        // check if email is correct and found inside json
        bool userExists = users != null && users.Exists(user => user.Email.Equals(email));
        if (users != null)
        {
            UserModel? user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                AuthenticatedUser.SetInfo(user);
            }
        }
        return userExists;
    }

    // get user posts 
    public async Task Posts()
    {
        AuthenticatedUser authUser = AuthenticatedUser.instence();
        if (authUser.user != null)
        {
            int id = authUser.user.Id;
            string json = await PostService.FindByRelation("users", id);
            List<PostModel> posts = JsonHelper.DeserializeJsonList<PostModel>(json) ?? new();

            if (posts != null)
            {
                foreach (PostModel post in posts)
                {
                    Console.WriteLine($"Id : {post.Id}");
                    Console.WriteLine($"Title : {post.Title}");
                    Console.WriteLine($"Body : {post.Body}");
                    Console.WriteLine("---------------");
                }
            }
            else
            {
                Console.WriteLine("No Results !");
            }
        }
    }
    // get user Albums
    public async Task Albums(int id)
    {

        string json = await AlbumService.FindByRelation("users", id);
        List<AlbumModel> albums = JsonHelper.DeserializeJsonList<AlbumModel>(json) ?? new();

        if (albums != null)
        {
            foreach (AlbumModel album in albums)
            {
                Console.WriteLine($"Id : {album.Id}");
                Console.WriteLine($"Title : {album.Title}");
                Console.WriteLine("--------------");
            }
        }
        else
        {
            Console.WriteLine("No Results !");
        }
            
    }

    // user todos
    public async Task Todos()
    {
        AuthenticatedUser authUser = AuthenticatedUser.instence();
        if (authUser.user != null)
        {
            int id = authUser.user.Id;
            string json = await TodoService.FindByRelation("users", id);
            List<TodoModel> todos = JsonHelper.DeserializeJsonList<TodoModel>(json) ?? new();

            if (todos != null)
            {
                foreach (TodoModel todo in todos)
                {
                    Console.WriteLine($"Id : {todo.Id}");
                    Console.WriteLine($"Title : {todo.Title}");
                    Console.WriteLine("--------------");
                }
            }
            else
            {
                Console.WriteLine("No Results !");
            }
        }
    }
}