using System;
using System.Configuration;
namespace TmobileTask.Utilities
{
    public static class Data
    {
        public static string BaseUrl => ConfigurationManager.AppSettings["BaseURL"];
        public static string UserName => ConfigurationManager.AppSettings["UserName"];
        public static string Password => ConfigurationManager.AppSettings["Password"];
    }
}
