using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolZadaniA.Model
{
    [Table("Samochody")]
    public class Samochod
    {
        [Key]
        public int SamochodId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Marka { get; set; }
        [MaxLength(20)]
        [Required]
        public string Model { get; set; }
        [Required]
        public int RokProdukcji { get; set; }
        [Required]
        public int Przebieg { get; set; }

        public override string ToString()
        {
            return $"Marka: {Marka}, Model: {Model}, Rok produkcji: {RokProdukcji}, Przebieg {Przebieg}";
        }
    }
}
