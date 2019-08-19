using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class Opravilo
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Oseba { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumZakljucka { get; set; }
    }
}
