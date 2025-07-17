namespace App.Models;

class Album : Model // inheritance
{
    public string Title { get; set; } = "";
    public int UserId { get; set; }

    public override string Type() 
    {
        return "Album";
    }
     public override string Description()
    {
        return "This Is a Model Represents a Album entity fetched from the API"; // polymorphism
    }
    
}