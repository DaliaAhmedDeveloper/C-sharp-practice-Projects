namespace App.Controller;
using App.Helpers;
using AlbumService = App.Services.Album;
using AlbumModel = App.Models.Album;
using PhotoModel = App.Models.Photo;

class Album : IController
{
    private static Album? _instance;
    private static readonly object _lock = new object();
    public static Album instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Album();
                }
            }
        }
        return _instance;
    }
    private Album() { }
    //Basic Mehods
    public async Task<string> GetAll() // fetch all records
    {
        return await AlbumService.Get();
    }
    public async Task ShowAll(bool download = false) // show all records
    {
        string json = await GetAll();
        if (download == true)
        {
            FileBuilder.Download(json);
        }
        // convert json to objects with case sensitive option 
        List<AlbumModel> albums = JsonHelper.DeserializeJsonList<AlbumModel>(json) ?? new();

        if (albums != null)
        {
            foreach (AlbumModel album in albums)
            {
                Console.WriteLine($"Id is {album.Id}");
                Console.WriteLine($"Title is {album.Title}");
                Console.WriteLine($"User Id is {album.UserId}");
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
        return await AlbumService.Find(id);
    }

    public async Task Show(int id) // show one record by id
    {
        string json = await Find(id);
        // convert json to objects with case sensitive option 
        AlbumModel album = JsonHelper.DeserializeJson<AlbumModel>(json) ?? new();

        if (album != null)
        {
            Console.WriteLine($"Id is {album.Id}");
            Console.WriteLine($"Title is {album.Title}");
            Console.WriteLine($"User Id is {album.UserId}");
            Console.WriteLine("---------------");
        }
        else
        {
            Console.WriteLine("No Results !");
        }

    }
    // extra Methos
     public async Task Photos(int id)
    {
        string json = await AlbumService.FindByRelation("posts", id);
        List<PhotoModel> photos = JsonHelper.DeserializeJsonList<PhotoModel>(json) ?? new();

        if (photos != null)
        {
            foreach (PhotoModel photo in photos)
            {
                Console.WriteLine($"Id : {photo.Id}");
                Console.WriteLine($"Title : {photo.Title}");
                Console.WriteLine($"Thumbnail Url : {photo.ThumbnailUrl}");
                Console.WriteLine($"Url : {photo.Url}");
                Console.WriteLine($"Album Id : {photo.AlbumId}");
                Console.WriteLine("--------------");
            }
        }
        else
        {
            Console.WriteLine("No Results !");
        }
            
    }
}