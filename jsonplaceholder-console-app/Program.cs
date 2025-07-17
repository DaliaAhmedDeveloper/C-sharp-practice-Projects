using Controllers =  App.Controller;
using App.Helpers;
using Models = App.Models;
class Program
{
    static async Task Main()
    {
        try
        {
             Controllers.User user = Controllers.User.instence();
             Controllers.Post post = Controllers.Post.instence();
             Controllers.Album album = Controllers.Album.instence();
            // string name = AppHelper.PromptUntilValid("Enter your name: ", input => !string.IsNullOrWhiteSpace(input));
            //auth
            string email = await AppHelper.TaskPromptUntilValid("Enter your valid Registered email: ", async input => await user.Auth(input) && input.Contains("@"));
            List<string> options =
            [
                "Enter 1 For Yor Profile Details\n" ,
                "Enter 2 To See Your Posts\n",
                "Enter 3 To See Your Albums\n",
                "Enter 4 To See Your Todos\n",
                "Enter 5 To See All Posts\n",
                "Enter 6 To See Post Comments\n",
                "Enter 7 To See All Albums\n",
                "Enter 8 To See Album Photos\n",
                "Enter 9 To See All Users\n",
                "Enter 10 To See User Albums\n",
                "Enter 11 To Download Latest Result In a file\n",
                "Enter 12 To Exist\n"
            ];
            string _options = "";
            foreach (string op in options)
            {
                _options += op;
            }
            while (true)
            {
                int option = int.Parse(AppHelper.PromptUntilValid(_options, input => int.TryParse(input, out int num) && (num > 0 && num <= 11)));

                if (option == 1)
                {
                    AuthenticatedUser authUser = AuthenticatedUser.instence();
                    Console.WriteLine("You Profile Details : ");
                    if (authUser.user != null)
                    {
                        Console.WriteLine($"Id : {authUser.user.Id}");
                        Console.WriteLine($"Name : {authUser.user.Name}");
                        Console.WriteLine($"Email : {authUser.user.Email}");
                        Console.WriteLine($"Phone : {authUser.user.Phone}");
                        Console.WriteLine($"Website :  {authUser.user.Website}");
                    }
                    else
                    {
                        Console.WriteLine("No Data To Show Or Something Went Wrong");
                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Your Posts : ");
                    await user.Posts();

                }
                else if (option == 3)
                {
                    Console.WriteLine("Your Albums : ");
                    AuthenticatedUser authUser = AuthenticatedUser.instence();
                    if (authUser.user != null)
                    {
                        int id = authUser.user.Id;
                        await user.Albums(id);
                    }

                }
                else if (option == 4)
                {
                    Console.WriteLine("Your Todos : ");
                    await user.Todos();

                }
                else if (option == 5)
                {
                    Console.WriteLine("All Application Posts : ");
                    string optionsTxt = "Enter 1 To show\nEnter 2 To Show And Download\n";
                    int _option = int.Parse(AppHelper.PromptUntilValid(optionsTxt, input => int.TryParse(input, out int num) && (num > 0 && num <= 2)));
                    bool download = false;
                    if (_option == 2) { download = true; }
                    Console.WriteLine("All Posts : ");
                    await post.ShowAll(download);

                }
                else if (option == 6)
                {
                    int id = int.Parse(AppHelper.PromptUntilValid("Please Enter Post Id\n", input => int.TryParse(input, out int num) && (num > 0)));
                    Console.WriteLine("Post Comments : ");
                    await post.Comments(id);

                }
                else if (option == 7)
                {
                    string optionsTxt = "Enter 1 To show\nEnter 2 To Show And Download\n";
                    int _option = int.Parse(AppHelper.PromptUntilValid(optionsTxt, input => int.TryParse(input, out int num) && (num > 0 && num <= 2)));
                    bool download = false;
                    if (_option == 2) { download = true; }
                    Console.WriteLine("All Albums : ");
                    await album.ShowAll(download);
                }
                else if (option == 8)
                {
                    int id = int.Parse(AppHelper.PromptUntilValid("Please Enter Album Id\n", input => int.TryParse(input, out int num) && (num > 0)));
                    Console.WriteLine("Album Photos : ");
                    await album.Photos(id);

                }
                else if (option == 9)
                {
                    string optionsTxt = "Enter 1 To show\nEnter 2 To Show And Download\n";
                    int _option = int.Parse(AppHelper.PromptUntilValid(optionsTxt, input => int.TryParse(input, out int num) && (num > 0 && num <= 2)));
                    bool download = false;
                    if (_option == 2) { download = true; }
                    Console.WriteLine("All Users : ");
                    await user.ShowAll(download);

                }
                else if (option == 10)
                {
                    int id = int.Parse(AppHelper.PromptUntilValid("Please Enter User Id\n", input => int.TryParse(input, out int num) && (num > 0)));
                    Console.WriteLine("User Albums : ");
                    await user.Albums(id);

                }
                else if (option == 11)
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Wrong Option ! Please Enter Correct One");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
    }
    
}
