namespace App.Helpers;
using System.Runtime.InteropServices;
static class FileBuilder
{
    public static void Download(string json)
    {
        try
        {
            string fileName = "File.txt";
            string downloadsPath = Path.Combine(GetDownloadsPath(), fileName);
            int i = 2;
            while (true)
            {
                if (File.Exists(downloadsPath))
                {
                    fileName = $"File_{i}.txt";
                    downloadsPath = Path.Combine(GetDownloadsPath(), fileName);
                }
                else
                {
                    break;
                }
                i++;
            }
            File.WriteAllText(downloadsPath, json);
           Console.WriteLine($"✅ File saved successfully at: {downloadsPath}");
        }
        catch (Exception e)
        {
           Console.WriteLine($"❌ Error saving file: {e.Message}");
        }
    }

    public static  string GetDownloadsPath()
    {
        string homePath;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Usually in Windows: C:\Users\Username\Downloads
            homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(homePath, "Downloads");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
                 RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // On Linux/macOS, Downloads is usually inside home directory
            homePath = Environment.GetEnvironmentVariable("HOME") ?? "~";
            return Path.Combine(homePath, "Downloads");
        }

        // Fallback if OS not recognized
        return "Downloads";
    }
}