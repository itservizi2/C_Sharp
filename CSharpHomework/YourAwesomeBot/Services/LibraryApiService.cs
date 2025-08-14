using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using YourAwesomeBot.Configuration;
using YourAwesomeBot.Models;

namespace YourAwesomeBot.Services
{
    public class LibraryApiService
    {
        private readonly HttpClient _httpClient;

        

        public LibraryApiService(HttpClient httpClient, IOptions<BotConfiguration> config)
        {
            _httpClient = httpClient;
            // _apiUrl = config.Value.LibraryApiUrl; 
        }

        public async Task<ApiResponse<Book>> GetBooksAsync(int page = 1, int pageSize = 10, string query = null)
        {
            
            var booksUrl = "https://mocki.io/v1/a6d06b93-60a8-48e0-b7c3-4473b83ac77c";

            // Note: Our simple mock API doesn't support query, page, or pageSize,
            // but we leave the parameters here so the bot logic doesn't break.
            var response = await _httpClient.GetStringAsync(booksUrl);
            return JsonConvert.DeserializeObject<ApiResponse<Book>>(response);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            // For now, this is harder to mock. We'll return a default book.
            return new Book { Id = id, Title = "A Mocked Book", Price = 9.99m };
        }

        public async Task<ApiResponse<Author>> GetAuthorsAsync(int page = 1, int pageSize = 10)
        {
            
            var authorsUrl = "https://mocki.io/v1/1ff54986-680c-4c05-b96a-95088b72f6f9";

            var response = await _httpClient.GetStringAsync(authorsUrl);
            return JsonConvert.DeserializeObject<ApiResponse<Author>>(response);
        }

        public async Task<Author> GetAuthorDetailsAsync(int id)
        {
            // For now, this is harder to mock. We'll return a default author.
            return new Author { Id = id, Name = "A Mocked Author" };
        }

        public async Task<ApiResponse<Category>> GetCategoriesAsync()
        {
            
            var categoriesUrl = "https://mocki.io/v1/709b8e00-6742-4892-ac6a-6bab96e35e67";

            var response = await _httpClient.GetStringAsync(categoriesUrl);
            
            var items = JsonConvert.DeserializeObject<ApiResponse<Category>>(response);
            return items;
        }
    }
}