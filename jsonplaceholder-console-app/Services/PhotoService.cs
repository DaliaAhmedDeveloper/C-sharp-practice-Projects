namespace App.Services;
using App.Helpers;

class Photo
{
     private readonly static string BaseUrl = ConfigApp.baseURL;
    // get all users
    public static async Task<string> Get()
    {
        string url = BaseUrl +"/photos";
        return await ServiceHelper.Service(url);
    }
     public static async Task<string> Find(int id)
    {
        string url = BaseUrl + "/photos/" + id;
        return await ServiceHelper.Service(url);
    }
}