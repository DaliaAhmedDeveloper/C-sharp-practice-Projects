class AppConfig
{
    public string ApiBaseUrl = "https://jsonplaceholder.typicode.com";

    private static AppConfig _instance;
    private static readonly object _lock = new object(); // just object variable to control access to the lock block

    private AppConfig() { } // private constructor -- so cant take object

    public static AppConfig instance()
    {

        if (_instance == null) // check if instance is null 
        {
            lock (_lock) // Thread safety -- prevent multiple threads from accessing the same block of code at the same time
            {
                if (_instance == null) // check one more time inside lock to insure no thread work on creating the instance while lock check the threads
                {
                    _instance = new AppConfig();
                }
            }
        }
        return _instance;
    }
}