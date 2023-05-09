using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OnlinePropertyPortal.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlinePropertyPortal.Pages.AddProperty
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [BindProperty]
        public Property Property { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PostAsJsonAsync("/api/properties", Property);

            return RedirectToPage("/Properties / Index");
}
    }
}