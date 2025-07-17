namespace App.Services;
using App.Helpers;

class Comment
{
     private readonly static string BaseUrl = ConfigApp.baseURL;
    // get all users
    public static async Task<string> Get()
    {
        string url = BaseUrl +"/comments";
        return await ServiceHelper.Service(url);
    }
     public static async Task<string> Find(int id)
    {
        string url = BaseUrl + "/comments/" + id;
        return await ServiceHelper.Service(url);
    }
}