
namespace App.Models;

class User : Model // inheritance
{
    public string Email { get; set; } = "";
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Website { get; set; } = "";

    public override string Type() 
    {
        return "User";
    }
     public override string Description()
    {
        return "This Is a Model Represents a User entity fetched from the API"; // polymorphism
    }

    public static implicit operator User(AuthenticatedUser v)
    {
        throw new NotImplementedException();
    }
}