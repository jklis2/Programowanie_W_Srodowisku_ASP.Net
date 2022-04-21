using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Pracownicy
    {
        public int PracownicyID { get; set; }

        [Required(ErrorMessage = "Wprowadź Numer Pesel Pracownika")]
        [Display(Name = "Pesel")]
        [MinLength(11)]
        [MaxLength(11)]
        [Column(TypeName = "varchar(11)")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Wprowadź cyfry")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Wprowadź Imię Pracownika")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Nazwisko Pracownika")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź Adres Pracownika")]
        [MaxLength(100)]
        [Display(Name = "Adres Zamieszkania")]
        public string AdresZamieszkania { get; set; }

        [Required(ErrorMessage = "Wprowadź Datę Zatrudnienia Pracownika")]
        [Display(Name = "Data Zatrudnienia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataZatrudnienia { get; set; }

        [Required(ErrorMessage = "Wprowadź Koniec Kontraktu Pracownika")]
        [Display(Name = "Koniec Kontraktu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime KoniecKontraktu { get; set; }

        public virtual Lekarze Lekarze { get; set; }
    }
}
