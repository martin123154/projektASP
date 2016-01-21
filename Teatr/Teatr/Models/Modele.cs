using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Teatr.Validators;

namespace Teatr.Models
{
    public class Scena
    {
        public Scena()
        {
            this.Przedstawienia = new List<Przedstawienie>();

        }
        [Display(Name = "ID")]
        [Key]
        public int scena_id { get; set; }
        [Nazwa]
        [Display(Name="Nazwa")]
        [Required]
        [RegularExpression("[A-Z]{1}[A-Za-z]*", ErrorMessage = "Nazwa musi sie składać z dużej litery")]
        public string nazwa { get; set; }
        [Wielkosc]
        [Required]
        [Display(Name = "Wielkość")]
        public string wielkosc { get; set; }
        [Required]
        [Display(Name = "Numer")]
        [Range(1, 999, ErrorMessage = "Proszę wprowadzić liczbę z przedziału 1-999.")]
        public int numer { get; set; }


        public virtual ICollection<Przedstawienie> Przedstawienia { get; set; }
    }

    public class Przedstawienie
    {
        public Przedstawienie() { }
        [Key]
        public int przedstawienie_id { get; set; }
        [Tytul]
        [Display(Name = "Tytuł")]
        [Required]
        [RegularExpression("[A-Z]{1}[A-Za-z]*", ErrorMessage = "Tytuł musi sie składać z dużej litery")]
        public string tytul { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        [Required]
        public DateTime data_rozp { get; set; }
        [Required]
        [Display(Name = "Data zakończenia")]
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