namespace App.Models;

class ToDo: Model // inheritance
{
    public string Title { get; set; } = "";
    public int UserId { get; set; } 
    public bool Completed { get; set; } 
    public override string Type() 
    {
        return "Todo";
    }
     public override string Description()
    {
        return "This Is a Model Represents a Todo entity fetched from the API"; // polymorphism
    }
}