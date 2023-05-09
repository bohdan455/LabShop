using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram
{
    public class TelegramBot
    {
        private readonly TelegramBotClient _bot;
        private readonly int _sellerId;
        public TelegramBot(IConfiguration config, MessagesReceiving receiving)
        {
            var token = config["Telegram:Token"];
            _sellerId = int.Parse(config["Telegram:SellerId"]);
            _bot = new TelegramBotClient(token);
            receiving.Start(_bot);
        }
        public async Task SendMessageAsync(string message)
        {
            await _bot.SendTextMessageAsync(_sellerId, message);
        }
        public async Task SendRequirementsAsync(Guid id,string message)
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
{
                // first row
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Відхилити", callbackData: $"Decline {id}"),
                    InlineKeyboardButton.WithCallbackData(text: "Виконано", callbackData: $"Done {id}"),
                }
            });
            await _bot.SendTextMessageAsync(_sellerId, message, replyMarkup: inlineKeyboard);
        }

    }
}
