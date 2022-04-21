using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Choroby
    {
        public int ChorobyID { get; set; }
        public int PacjenciID { get; set; }
        public int PracownicyID { get; set; }
        public int IdPacjenta { get; set; }
        public string PrzebiegChoroby { get; set; }

        public virtual Recepty Id { get; set; }
        public virtual Pacjenci IdPacjentaNavigation { get; set; }
        public virtual Lekarze IdPracownikaNavigation { get; set; }
    }
}
