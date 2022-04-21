using System;
using System.Collections.Generic;

#nullable disable

namespace PrzychodniaFinal.Models
{
    public partial class Lekarze
    {
        public int LekarzeID { get; set; }
        public string Specjalizacja { get; set; }
        public int NumerGabinetu { get; set; }
    }
}
