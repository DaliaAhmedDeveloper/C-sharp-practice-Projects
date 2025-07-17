
namespace App.Helpers;

static class AppHelper
{
    public static string PromptUntilValid(string prompt, Func<string, bool> isValid)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine() ?? "";
        }
        while (!isValid(input));

        return input;
    }
    
     public  static async Task<string> TaskPromptUntilValid(string prompt, Func<string, Task<bool>> isValid)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine() ?? "";
        }
        while (! await isValid(input));

        return input;
    }

}