using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Prediction.Model;

namespace Prediction.Pages
{
    public class Dashboard : PageModel
    {

        public DashboardViewModel DataSource { get; set; }

        public IActionResult OnGet(string source)
        {
            DataSource = DataSource != null ? DataSource : JsonConvert.DeserializeObject<DashboardViewModel>(TempData["DashboardSource"].ToString());

            return this.Page();
        }
    }
}
