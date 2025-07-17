/// <summary>
/// The base class for all data models in the application.
/// Provides shared functionality and structure to be inherited by specific models such as User, Post, Comment, etc.
/// This class can define common methods like ID handling, basic validation, or description.
/// </summary>
abstract class Model
{
    public int Id { get; set; }
    public abstract string Type();
    public virtual string Description()
    {
        return "This Is a Model Represents an entity fetched from the API";
    }
    // Checks if the model has a valid (non-zero) ID.
    public virtual bool HasValidId()
    {
        return Id > 0;
    }

}