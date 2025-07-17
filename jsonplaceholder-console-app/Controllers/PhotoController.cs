namespace App.Controller;
using App.Helpers;
using PhotoService = App.Services.Photo;
using PhotoModel = App.Models.Photo;
class Photo : IController
{
    private static Photo? _instance;
    private static readonly object _lock = new object();
     public static Photo instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Photo();
                }
            }
        }
        return _instance;
    }
    private Photo() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await PhotoService.Get();
    }
    public async Task ShowAll( bool download = false ) // show all records
    {
        string json = await GetAll();
        // convert json to objects with case sensitive option 
        List<PhotoModel> photos = JsonHelper.DeserializeJsonList<PhotoModel>(json) ?? new();

        if (photos != null)
        {
            foreach (PhotoModel photo in photos)
            {
               Console.WriteLine($"Id is {photo.Id}");
                Console.WriteLine($"Album Id is {photo.AlbumId}");
                Console.WriteLine($"Title is {photo.Title}");
                Console.WriteLine($"Photo url is {photo.Url}");
                Console.WriteLine($"Photo ThumbnailUrl is  {photo.ThumbnailUrl}");
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
        return await PhotoService.Find(id);
    }
    
     public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        PhotoModel photo = JsonHelper.DeserializeJson<PhotoModel>(json) ?? new();
       
        if (photo != null)
        {
                Console.WriteLine($"Id is {photo.Id}");
                Console.WriteLine($"Album Id is {photo.AlbumId}");
                Console.WriteLine($"Title is {photo.Title}");
                Console.WriteLine($"Photo url is {photo.Url}");
                Console.WriteLine($"Photo ThumbnailUrl is  {photo.ThumbnailUrl}");
                Console.WriteLine("---------------");
        }
        else
        {
             Console.WriteLine("No Results !");
        }

    }
    // extra Methos
}