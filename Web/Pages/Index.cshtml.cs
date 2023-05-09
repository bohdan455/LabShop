using DataAccess;
using DataAccess.Model;
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
        private readonly DataContext _context;

        public IndexModel(ILogger<IndexModel> logger, TelegramBot bot,DataContext context)
        {
            _logger = logger;
            _bot = bot;
            _context = context;
        }

        [BindProperty]
        public ClientRequest ClientRequest { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            var guid = Guid.NewGuid();
            await _context.WorkRequests.AddAsync(new WorkRequest
            {
                Id = guid,
                Username = ClientRequest.TelegramUsername,
                Requirements = ClientRequest.Requirement
            });
            await _context.SaveChangesAsync();
            await _bot.SendRequirementsAsync(guid,ClientRequest.ToString());

            return RedirectToPage();
        }
    }
}