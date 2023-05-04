using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram
{
    public class TelegramBot
    {
        private readonly TelegramBotClient _bot;
        private readonly int _sellerId;
        public TelegramBot(IConfiguration config)
        {
            var token = config["Telegram:Token"];
            _sellerId = int.Parse(config["Telegram:SellerId"]);
            _bot = new TelegramBotClient(token);

        }
        public async Task SendMessage(string message)
        {
            await _bot.SendTextMessageAsync(_sellerId, message);
        }
    }
}
