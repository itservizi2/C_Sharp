using Azure;
using Azure.AI.OpenAI; 
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using YourAwesomeBot.Configuration;
using YourAwesomeBot.Models;

namespace YourAwesomeBot.Services
{
    public class OpenAiService
    {
        private readonly OpenAIClient _openAiClient;

        public OpenAiService(IOptions<BotConfiguration> config)
        {
            if (string.IsNullOrEmpty(config.Value.OpenAiApiKey))
            {
                throw new System.ArgumentException("OpenAI API Key is not configured in appsettings.json");
            }

            
            _openAiClient = new OpenAIClient(config.Value.OpenAiApiKey);
        }

        public async Task<string> GetSimilarBooksAsync(Book book)
        {
            var prompt = $"Recommend 3 books that are similar to the book '{book.Title}'. Provide only the book titles and authors.";

            var completionOptions = new CompletionsOptions
            {
                
                DeploymentName = "gpt-3.5-turbo-instruct",
                Prompts = { prompt },
                MaxTokens = 150,
                Temperature = 0.7f,
            };

            try
            {
                
                Response<Azure.AI.OpenAI.Completions> response = await _openAiClient.GetCompletionsAsync(completionOptions);

                string recommendation = response.Value.Choices.FirstOrDefault()?.Text.Trim();

                return string.IsNullOrEmpty(recommendation)
                    ? "Sorry, I couldn't generate a recommendation."
                    : recommendation;
            }
            catch (RequestFailedException ex)
            {
                
                System.Console.WriteLine($"OpenAI API Error: {ex.Message}");
                if (ex.Status == 401)
                {
                    return "Sorry, there is an issue with the API key configuration.";
                }
                if (ex.Message.Contains("deployment not found"))
                {
                    return "Sorry, the specified AI model is not available.";
                }
                return "Sorry, I couldn't connect to the recommendation service right now.";
            }
        }
    }
}