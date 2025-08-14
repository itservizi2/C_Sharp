
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions; 
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using YourAwesomeBot.Helpers;
using YourAwesomeBot.Services;


namespace YourAwesomeBot.Controllers
{
    public class TelegramBotController
    {
        private readonly LibraryApiService _libraryApiService;
        private readonly OpenAiService _openAiService;

        public TelegramBotController(LibraryApiService libraryApiService, OpenAiService openAiService)
        {
            _libraryApiService = libraryApiService;
            _openAiService = openAiService;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message when update.Message?.Text != null
                    => HandleMessageAsync(botClient, update.Message, cancellationToken),

                UpdateType.CallbackQuery when update.CallbackQuery != null
                    => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),

                _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken)
            };

            await handler;
        }

        private async Task HandleMessageAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            var messageText = message.Text;
            var chatId = message.Chat.Id;
            var commandParts = messageText.Split(' ', 2);
            var command = commandParts[0];
            var arguments = commandParts.Length > 1 ? commandParts[1] : string.Empty;

            Console.WriteLine($"Received command '{command}' with arguments '{arguments}' in chat {chatId}.");

            var action = command switch
            {
                "/start" => botClient.SendTextMessageAsync(chatId, "Welcome! Use the menu to browse the library.", cancellationToken: cancellationToken),
                "/books" => SendBookListAsync(botClient, chatId, 1, cancellationToken),
                "/authors" => SendAuthorListAsync(botClient, chatId, 1, cancellationToken),
                "/categories" => SendCategoryListAsync(botClient, chatId, cancellationToken),
                "/search" => SendBookListAsync(botClient, chatId, 1, cancellationToken, searchQuery: arguments),
                _ => botClient.SendTextMessageAsync(chatId, "Unknown command.", cancellationToken: cancellationToken)
            };

            await action;
        }

        private async Task HandleCallbackQueryAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery, CancellationToken cancellationToken)
        {
            var callbackData = callbackQuery.Data;
            var chatId = callbackQuery.Message.Chat.Id;
            var messageId = callbackQuery.Message.MessageId;

            Console.WriteLine($"Received callback '{callbackData}' in chat {chatId}.");

            var parts = callbackData.Split('_');
            var type = parts[0];

            if (type == "books" && parts.Length > 2 && parts[1] == "page" && int.TryParse(parts[2], out var bookPage))
            {
                await UpdateBookListAsync(botClient, chatId, messageId, bookPage, cancellationToken);
            }
            else if (type == "authors" && parts.Length > 2 && parts[1] == "page" && int.TryParse(parts[2], out var authorPage))
            {
                await UpdateAuthorListAsync(botClient, chatId, messageId, authorPage, cancellationToken);
            }

            await botClient.AnswerCallbackQueryAsync(callbackQuery.Id, cancellationToken: cancellationToken);
        }

        private async Task SendBookListAsync(ITelegramBotClient botClient, long chatId, int page, CancellationToken cancellationToken, string searchQuery = null)
        {
            var response = await _libraryApiService.GetBooksAsync(page, 10, searchQuery);
            var sb = new StringBuilder();

            if (response != null && response.Items.Any())
            {
                sb.AppendLine(string.IsNullOrEmpty(searchQuery) ? "*Here are the books:*" : $"*Search results for '{searchQuery}':*");
                foreach (var book in response.Items) sb.AppendLine($"- {book.Title}");
                var keyboard = PaginationHelper.CreatePaginationKeyboard(response.PageNumber, response.TotalPages, "books");
                await botClient.SendTextMessageAsync(chatId, sb.ToString(), parseMode: ParseMode.Markdown, replyMarkup: keyboard, cancellationToken: cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "No books found.", cancellationToken: cancellationToken);
            }
        }

        private async Task UpdateBookListAsync(ITelegramBotClient botClient, long chatId, int messageId, int page, CancellationToken cancellationToken, string searchQuery = null)
        {
            var response = await _libraryApiService.GetBooksAsync(page, 10, searchQuery);
            var sb = new StringBuilder();
            sb.AppendLine(string.IsNullOrEmpty(searchQuery) ? "*Here are the books:*" : $"*Search results for '{searchQuery}':*");
            foreach (var book in response.Items) sb.AppendLine($"- {book.Title}");
            var keyboard = PaginationHelper.CreatePaginationKeyboard(response.PageNumber, response.TotalPages, "books");
            await botClient.EditMessageTextAsync(chatId, messageId, sb.ToString(), parseMode: ParseMode.Markdown, replyMarkup: keyboard, cancellationToken: cancellationToken);
        }

        private async Task SendAuthorListAsync(ITelegramBotClient botClient, long chatId, int page, CancellationToken cancellationToken)
        {
            var response = await _libraryApiService.GetAuthorsAsync(page, 10);
            var sb = new StringBuilder();

            if (response != null && response.Items.Any())
            {
                sb.AppendLine("*Here are the authors:*");
                foreach (var author in response.Items) sb.AppendLine($"- {author.Name}");
                var keyboard = PaginationHelper.CreatePaginationKeyboard(response.PageNumber, response.TotalPages, "authors");
                await botClient.SendTextMessageAsync(chatId, sb.ToString(), parseMode: ParseMode.Markdown, replyMarkup: keyboard, cancellationToken: cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "No authors found.", cancellationToken: cancellationToken);
            }
        }

        private async Task UpdateAuthorListAsync(ITelegramBotClient botClient, long chatId, int messageId, int page, CancellationToken cancellationToken)
        {
            var response = await _libraryApiService.GetAuthorsAsync(page, 10);
            var sb = new StringBuilder();
            sb.AppendLine("*Here are the authors:*");
            foreach (var author in response.Items) sb.AppendLine($"- {author.Name}");
            var keyboard = PaginationHelper.CreatePaginationKeyboard(response.PageNumber, response.TotalPages, "authors");
            await botClient.EditMessageTextAsync(chatId, messageId, sb.ToString(), parseMode: ParseMode.Markdown, replyMarkup: keyboard, cancellationToken: cancellationToken);
        }

        private async Task SendCategoryListAsync(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var response = await _libraryApiService.GetCategoriesAsync();
            var sb = new StringBuilder();
            if (response != null && response.Items.Any())
            {
                sb.AppendLine("*Available Categories:*");
                foreach (var category in response.Items) sb.AppendLine($"- {category.Name} ({category.BookCount} books)");
                await botClient.SendTextMessageAsync(chatId, sb.ToString(), parseMode: ParseMode.Markdown, cancellationToken: cancellationToken);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "No categories found.", cancellationToken: cancellationToken);
            }
        }

        private Task HandleUnknownUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Received unknown update type: {update.Type}");
            return Task.CompletedTask;
        }
    }
}