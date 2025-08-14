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
        private readonly string _apiUrl;

        public LibraryApiService(HttpClient httpClient, IOptions<BotConfiguration> config)
        {
            _httpClient = httpClient;
            _apiUrl = config.Value.LibraryApiUrl;
        }

        public async Task<ApiResponse<Book>> GetBooksAsync(int page = 1, int pageSize = 10, string query = null)
        {
            var builder = new UriBuilder($"{_apiUrl}/books");
            var queryParams = HttpUtility.ParseQueryString(builder.Query);
            queryParams["Page"] = page.ToString();
            queryParams["PageSize"] = pageSize.ToString();
            if (!string.IsNullOrEmpty(query))
            {
                queryParams["Query"] = query;
            }
            builder.Query = queryParams.ToString();

            var response = await _httpClient.GetStringAsync(builder.ToString());
            return JsonConvert.DeserializeObject<ApiResponse<Book>>(response);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/books/{id}");
            return JsonConvert.DeserializeObject<Book>(response);
        }

        public async Task<ApiResponse<Author>> GetAuthorsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/authors?Page={page}&PageSize={pageSize}");
            return JsonConvert.DeserializeObject<ApiResponse<Author>>(response);
        }

        public async Task<Author> GetAuthorDetailsAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/authors/{id}");
            return JsonConvert.DeserializeObject<Author>(response);
        }

        public async Task<ApiResponse<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}/categories");
            return JsonConvert.DeserializeObject<ApiResponse<Category>>(response);
        }
    }
}