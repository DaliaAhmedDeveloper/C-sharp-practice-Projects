namespace App.Models;

class Post : Model
{
    public string Title { get; set; } = "";
    public string Body { get; set; } = "";
    public int UserId { get; set; }

     public override string Type()
    {
        return "Post";
    }
     public override string Description()
    {
        return "This Is a Model Represents a Post entity fetched from the API"; // polymorphism
    }
}