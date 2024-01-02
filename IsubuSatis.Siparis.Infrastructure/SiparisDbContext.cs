using IsubuSatis.Siparis.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuSatis.Siparis.Infrastructure
{
    public  class SiparisDbContext : DbContext
    {
        

        public DbSet<Siparis.Domain.Siparis> Siparisler { get; set; }
        public DbSet<Siparis.Domain.SiparisItem> SiparisItemlari { get; set; }

        public SiparisDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
