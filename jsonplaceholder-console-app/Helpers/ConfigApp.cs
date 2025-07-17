namespace App.Helpers;

static class ConfigApp
{
    private static AppConfig app_ = AppConfig.instance();
    public static string baseURL = app_.ApiBaseUrl;
}