using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class PersonelCdn
    {
        public int Id { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public bool? Zatrudnienie { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string MiejsceZamieszkania { get; set; }
        public string Ulica { get; set; }
    }
}
