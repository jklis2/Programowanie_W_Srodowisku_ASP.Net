using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public class Pacjenci
    {
        public int PacjenciID { get; set; }

        [Required(ErrorMessage = "Wprowadź Imię Pacjenta")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Wprowadź Nazwisko Pacjenta")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Wprowadź Numer Pesel Pacjenta")]
        [Display(Name = "Pesel")]
        [MinLength(11)]
        [MaxLength(11)]
        [Column(TypeName = "varchar(11)")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Wprowadź cyfry")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Wprowadź Datę Urodzenia Pacjenta")]
        [Display(Name = "Data Urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataUrodzenia { get; set; }

        [Required(ErrorMessage = "Wprowadź Adres Pacjenta")]
        [MaxLength(100)]
        [Display(Name = "Adres")]     
        public string AdresZamieszkania { get; set; }
        public virtual ICollection<Choroby> Chorobies { get; set; }
        public virtual ICollection<Recepty> Recepties { get; set; }
        public Pacjenci()
        {
            Chorobies = new HashSet<Choroby>();
        }
    }
}
