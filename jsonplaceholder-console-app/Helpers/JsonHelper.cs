namespace App.Helpers;
using System.Text.Json;
static class JsonHelper
{
    static public List<T>? DeserializeJsonList<T>(string json) // generic method that can able any type of json
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        // convert json to objects with case sensitive option 
        List<T>? result = JsonSerializer.Deserialize<List<T>>(json, options);
        return result;
    }

    static public T? DeserializeJson<T>(string json) // generic method that can able any type of json
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        // convert json to objects with case sensitive option 
        T? result = JsonSerializer.Deserialize<T>(json, options);
        return result;
    }

}