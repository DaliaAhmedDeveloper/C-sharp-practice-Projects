namespace App.Models;

class Photo : Model // inheritance
{
    public string Title { get; set; } = "";
    public string Url { get; set; } = "";
    public string ThumbnailUrl { get; set; } = "";
    public int AlbumId { get; set; } 

    public override string Type() 
    {
        return "Photo";
    }
     public override string Description()
    {
        return "This Is a Model Represents a Photo entity fetched from the API"; // polymorphism
    }
    
}