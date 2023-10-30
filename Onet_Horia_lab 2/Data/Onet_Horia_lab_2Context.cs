using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onet_Horia_lab_2.Models;
using Onet_Horia_lab_2;

namespace Onet_Horia_lab_2.Data
{
    public class Onet_Horia_lab_2Context : DbContext
    {
        public Onet_Horia_lab_2Context (DbContextOptions<Onet_Horia_lab_2Context> options)
            : base(options)
        {
        }

        public DbSet<Onet_Horia_lab_2.Models.Book> Book { get; set; } = default!;

        public DbSet<Onet_Horia_lab_2.Models.Publisher>? Publisher { get; set; }
    }
}
