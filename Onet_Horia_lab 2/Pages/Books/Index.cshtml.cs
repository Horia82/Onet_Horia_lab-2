using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onet_Horia_lab_2.Data;
using Onet_Horia_lab_2.Models;

namespace Onet_Horia_lab_2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context _context;

        public IndexModel(Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
