using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium8GP.Model
{
    [Table("Ksiazki")]
    public class Ksiazka
    {
        [Key]
        public int KsiazkaId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Tytul {  get; set; }
        [MaxLength(60)]
        [Required]
        public string Autor { get; set; }
        [MaxLength(13)]
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int LiczbaStron { get; set; }


        public override string ToString()
        {
            return $"Id: {KsiazkaId}, Tytul: {Tytul}, Autor: {Autor}, ISBN: {ISBN}, Liczba stron: {LiczbaStron}";
        }
    }
}
