using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Onet_Horia_lab_2.Data;
using Onet_Horia_lab_2.Models;
using Onet_Horia_lab_2.Models.ViewModels;

namespace Onet_Horia_lab_2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context _context;

        public IndexModel(Onet_Horia_lab_2.Data.Onet_Horia_lab_2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;
            }
        }
    }
}
