using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YourAwesomeBot.Configuration;
using YourAwesomeBot.Controllers;
using YourAwesomeBot.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<BotConfiguration>(context.Configuration.GetSection("BotConfiguration"));
                services.AddHttpClient<LibraryApiService>();
                services.AddSingleton<TelegramBotController>();
                services.AddSingleton<OpenAiService>();
                services.AddHostedService<TelegramBotService>();
            })
            .Build();

        await host.RunAsync();
    }
}