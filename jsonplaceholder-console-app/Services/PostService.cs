namespace App.Services;
using App.Helpers;

class Post
{
    private readonly static string BaseUrl = ConfigApp.baseURL;
    // get all users
    public static async Task<string> Get()
    {
        string url = BaseUrl + "/posts";
        return await ServiceHelper.Service(url);
    }
    public static async Task<string> Find(int id)
    {
        string url = BaseUrl + "/posts/" + id;
        return await ServiceHelper.Service(url);
    }   
     public static async Task<string> FindByRelation(string relation,int id)
    {
        string url = $"{BaseUrl}/{relation}/{id}/posts";
        return await ServiceHelper.Service(url);
    }   
}