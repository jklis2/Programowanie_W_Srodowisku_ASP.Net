using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Recepty
    {
        [Key]

        public int IdChoroby { get; set; }
        public int IdRecepty { get; set; }

        [Required(ErrorMessage = "Wprowadź Lek")]
        [Display(Name = "Lek")]
        public string Lek { get; set; }

        [Required(ErrorMessage = "Wprowadź Datę Wystawienia")]
        [Display(Name = "DataWystawienia")]
        [RegularExpression("d/M/yyyy || dd/M/yyyy || d/MM/yyyy || dd/MM/yyyy")]
        public string DataWystawienia { get; set; }

        public virtual ICollection<Choroby> Chorobies { get; set; }
        public Recepty()
        {
            Chorobies = new HashSet<Choroby>();
        }
    }
}
