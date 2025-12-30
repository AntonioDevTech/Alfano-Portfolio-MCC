using Microsoft.AspNetCore.Mvc; // logic for "BindProperty"
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlfanoWebDev.Models;
using AlfanoWebDev.Services;

namespace AlfanoWebDev.Pages
{
    public class IndexModel : PageModel
    {
        public List<MediaAsset> MediaItems { get; set; } = new List<MediaAsset>();

        // This holds the data form the user types in
        [BindProperty]
        public ContactMessage Contact { get; set; }

        public void OnGet()
        {
            DatabaseService db = new DatabaseService();
            MediaItems = db.GetAllMedia();
        }

        // This runs when the user clicks "Send Message"
        public IActionResult OnPost()
        {
            if (Contact != null)
            {
                DatabaseService db = new DatabaseService();
                db.InsertMessage(Contact); // Saves to SQL
            }
            return RedirectToPage(); // Refreshes the page
        }
    }
}