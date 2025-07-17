namespace App.Controller;
using App.Helpers;
using ToDoService = App.Services.ToDo;
using ToDoModel = App.Models.ToDo;
class ToDo : IController
{
    private static ToDo? _instance;
    private static readonly object _lock = new object();
     public static ToDo instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ToDo();
                }
            }
        }
        return _instance;
    }
    private ToDo() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await ToDoService.Get();
    }
    public async Task ShowAll( bool download = false ) // show all records
    {
        string json = await GetAll();
        if (download == true)
        {
            FileBuilder.Download(json);
        }
        // convert json to objects with case sensitive option 
        List<ToDoModel> toDos = JsonHelper.DeserializeJsonList<ToDoModel>(json) ?? new();

        if (toDos != null)
        {
            foreach (ToDoModel toDo in toDos)
            {
                Console.WriteLine($"Id is {toDo.Id}");
                Console.WriteLine($"Title is {toDo.Title}");
                Console.WriteLine($"User Id is {toDo.UserId}");
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
        return await ToDoService.Find(id);
    }
    
     public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        ToDoModel toDo = JsonHelper.DeserializeJson<ToDoModel>(json) ?? new();
       
        if (toDo != null)
        {
              Console.WriteLine($"Id is {toDo.Id}");
                Console.WriteLine($"Title is {toDo.Title}");
                Console.WriteLine($"User Id is {toDo.UserId}");
                Console.WriteLine("---------------");
        }
        else
        {
             Console.WriteLine("No Results !");
        }

    }
    // extra Methos
}