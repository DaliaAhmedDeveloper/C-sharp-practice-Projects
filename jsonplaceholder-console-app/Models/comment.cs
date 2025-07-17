namespace App.Models;

class Comment : Model // inheritance
{
    public string Email { get; set; } = "";
    public string Name { get; set; } = "";
    public string Body { get; set; } = "";
    public int PostId { get; set; }

    public override string Type() 
    {
        return "Comment";
    }
     public override string Description()
    {
        return "This Is a Model Represents a Comment entity fetched from the API"; // polymorphism
    }
    
}