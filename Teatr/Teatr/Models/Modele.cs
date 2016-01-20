using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace Teatr.Models
{
    public class Scena
    {
        public Scena()
        {
            this.Przedstawienia = new List<Przedstawienie>();

        }
        [Key]
        public int scena_id { get; set; }
        public string nazwa { get; set; }
        public string wielkosc { get; set; }
        public int numer { get; set; }


        public virtual ICollection<Przedstawienie> Przedstawienia { get; set; }
    }

    public class Przedstawienie
    {
        public Przedstawienie() { }
        [Key]
        public int przedstawienie_id { get; set; }
        public string tytul { get; set; }
        public DateTime data_rozp { get; set; }
        public DateTime data_zak { get; set; }

        public int scena_id { get; set; }

        [ForeignKey("scena_id")]
        public virtual Scena Scena { get; set; }

    }
    public class MyDBContext : DbContext
    {
        public DbSet<Scena> Sceny { get; set; }
        public DbSet<Przedstawienie> Przedstawienia { get; set; }

    }
}