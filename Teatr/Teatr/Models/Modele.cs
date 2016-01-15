using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace Teatr.Models
{
    public class Scena
    {
        public Scena()
        {
            this.Sceny = new List<Scena>();

        }

        public int scena_id { get; set; }
        public string nazwa { get; set; }
        public string wielkosc { get; set; }
        public int numer { get; set; }
   

        public virtual ICollection<Scena> Sceny { get; set; }
    }

    public class Przedstawienie
    {
        public Przedstawienie() { }

        public int przedstawienie_id { get; set; }
        public string tytul { get; set; }
        public DateTime data_rozp { get; set; }
        public DateTime data_zak { get; set; }

        public int scena_id { get; set; }

        public virtual Scena Scena { get; set; }

    }
    public class MyDBContext : DbContext
    {
        public DbSet<Scena> Sceny { get; set; }
        public DbSet<Przedstawienie> Przedstawienia { get; set; }

    }
}
