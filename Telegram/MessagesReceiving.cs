using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using DataAccess;

namespace Telegram
{
    public class MessagesReceiving
    {
        //private readonly DataContext _context;

        //public MessagesReceiving(DataContext context)
        //{
        //    _context = context;
        //}
        public async Task Start(TelegramBotClient bot)
        {
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                if (update.Type == UpdateType.CallbackQuery)
                {
                    var command = update.CallbackQuery.Data.Split(" ")[0];
                    var value = update.CallbackQuery.Data.Split(" ")[1];
                    if (command == "Decline")
                    {
                        //var workRequest = _context.WorkRequests.FirstOrDefault(wr => wr.Id.ToString() == value);
                        //workRequest.Status = 2;

                        //await _context.SaveChangesAsync();
                        Console.WriteLine(update.CallbackQuery.Data);
                        await botClient.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);

                    }
                    else if (command == "Done")
                    {
                        //var workRequest = _context.WorkRequests.FirstOrDefault(wr => wr.Id.ToString() == value);
                        //workRequest.Status = 1;

                        //await _context.SaveChangesAsync();
                        Console.WriteLine(update.CallbackQuery.Data);
                        await botClient.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                }
            }

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            bot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions
            );

            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };
                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }
        }
    }
}
