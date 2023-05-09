using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OnlineProperty.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlinePropertyPortal.Pages.EditProperty
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

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Property Property { get; set; }

        public async Task OnGetAsync()
        {
            Property = await _httpClient.GetFromJsonAsync<Property>($"/api/properties/{Id}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PutAsJsonAsync($"/api/properties/{Id}", Property);

            return RedirectToPage("/Properties/Index");
        }
    }
}
