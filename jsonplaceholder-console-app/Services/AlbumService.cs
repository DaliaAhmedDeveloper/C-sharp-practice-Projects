namespace App.Services;
using App.Helpers;

class Album
{
    private readonly static string BaseUrl = ConfigApp.baseURL;
    // get all users
    public static async Task<string> Get()
    {
        string url = BaseUrl + "/albums";
        return await ServiceHelper.Service(url);
    }
    public static async Task<string> Find(int id)
    {
        string url = BaseUrl + "/albums/" + id;
        return await ServiceHelper.Service(url);
    }
     public static async Task<string> FindByRelation(string relation,int id)
    {
        string url = $"{BaseUrl}/{relation}/{id}/albums";
        return await ServiceHelper.Service(url);
    }   
}