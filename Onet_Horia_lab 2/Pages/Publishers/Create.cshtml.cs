using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onet_Horia_lab_2.Data;
using Onet_Horia_lab_2.Models;

namespace Onet_Horia_lab_2.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context _context;

        public CreateModel(Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Publisher == null || Publisher == null)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
