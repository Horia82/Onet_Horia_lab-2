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

        public IList<Book> Book { get; set; } = default!;
        public IEnumerable<Book> BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }



        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            // using System;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CurrentFilter = searchString;
            BookD = await _context.Book
           .Include(b => b.Publisher)
           .AsNoTracking()
           .OrderBy(b => b.Title)
           .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                BookD = BookD.Where(s=> s.Title.Contains(searchString));
            }
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Where(i => i.ID == id.Value).Single();
               
            }
        }

    }
}

        
       
