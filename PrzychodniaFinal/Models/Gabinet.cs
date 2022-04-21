using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Gabinet
    {
        public Gabinet()
        {
            Lekarzes = new HashSet<Lekarze>();
        }

        public int NumerGabinetu { get; set; }
        public string DupaJasia { get; set; }

        public virtual ICollection<Lekarze> Lekarzes { get; set; }
    }
}
