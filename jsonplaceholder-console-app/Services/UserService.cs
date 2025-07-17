namespace App.Services;
using App.Helpers;
class User
{
    private readonly static string BaseUrl = ConfigApp.baseURL;
    // get all users
    public static async Task<string> Get()
    {
        string url = BaseUrl +"/users";
        return await ServiceHelper.Service(url);
    }
     public static async Task<string> Find(int id)
    {
        string url = BaseUrl + "/users/" + id;
        return await ServiceHelper.Service(url);
    }
}