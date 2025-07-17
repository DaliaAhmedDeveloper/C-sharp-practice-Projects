namespace App.Helpers;

static class ServiceHelper
{
    public static async Task<string> Service(string url)
    {
        string json = "";
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{url}");
                if (response.IsSuccessStatusCode)
                {
                    //read the json as string
                    json = await response.Content.ReadAsStringAsync();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
        return json;
    }
    
}