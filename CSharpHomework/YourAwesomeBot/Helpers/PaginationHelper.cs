using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace YourAwesomeBot.Helpers
{
    public static class PaginationHelper
    {
       
        public static InlineKeyboardMarkup CreatePaginationKeyboard(int currentPage, int totalPages, string callbackPrefix)
        {
            var buttons = new List<InlineKeyboardButton>();

            
            if (currentPage > 1)
            {
                buttons.Add(InlineKeyboardButton.WithCallbackData("⬅️ Previous", $"{callbackPrefix}_page_{currentPage - 1}"));
            }

            
            if (currentPage < totalPages)
            {
                buttons.Add(InlineKeyboardButton.WithCallbackData("Next ➡️", $"{callbackPrefix}_page_{currentPage + 1}"));
            }

           
            return new InlineKeyboardMarkup(buttons);
        }
    }
}