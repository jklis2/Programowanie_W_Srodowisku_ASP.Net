using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Specjalizacja
    {
        public Specjalizacja()
        {
            Lekarzes = new HashSet<Lekarze>();
        }

        public string Specjalizacja1 { get; set; }

        public virtual ICollection<Lekarze> Lekarzes { get; set; }
    }
}
