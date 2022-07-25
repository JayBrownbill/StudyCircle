using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;

namespace StudyCircle.API.Tests.Config
{
    public static class TestConfiguration
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            var config = builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
            return config.GetConnectionString("DefaultConnection");
        }
    }
}