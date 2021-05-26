using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KsiazkaKucharska.Model
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Czas { get; set; }
        public string Porcja { get; set; }
        public string Skladniki { get; set; }
        public string Instrukcje { get; set; }
        public string Zdjecie { get; set; }
        public string Rodzaj { get; set; }


    }
}
