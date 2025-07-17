using App.Models;
class AuthenticatedUser
{
    private static User? _user;
    public User? user
    {
        get
        {
            return _user;
        }
    }
    // apply singleton 
    private static AuthenticatedUser? _instance;
    private static readonly object _lock = new object();
    private AuthenticatedUser() { } // pervent creating objects from the class

    public static AuthenticatedUser instence()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AuthenticatedUser();
                }
            }
        }
        return _instance;
    }
    public static void SetInfo(User user)
    {
        _user = user;
    }

}