using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telegram;
using Web.Models;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TelegramBot _bot;

        public IndexModel(ILogger<IndexModel> logger, TelegramBot bot)
        {
            _logger = logger;
            _bot = bot;
        }

        [BindProperty]
        public ClientRequest ClientRequest { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _bot.SendMessage(ClientRequest.ToString());

            return Page();
        }
    }
}