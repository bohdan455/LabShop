using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Requests.Abstractions;

namespace Web.Models
{
    public class ClientRequest
    {
        [Required]
        public string TelegramUsername { get; set; }
        [Required]
        public string Requirement { get; set; }
        public override string ToString()
        {
            return $"Нове замовлення\nТелеграм нікнейм: {TelegramUsername}" +
                $"\nТекст замовлення: {Requirement}";
        }
    }
}
