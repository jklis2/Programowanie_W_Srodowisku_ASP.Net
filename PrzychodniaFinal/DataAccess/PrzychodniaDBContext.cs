using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.DataAccess
{
    public class PrzychodniaDBContext : DbContext
    {
        public PrzychodniaDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pacjenci> Pacjencis { get; set; }
        public DbSet<Recepty> Recepties { get; set; }
        public DbSet<Lekarze> Lekarzes { get; set; }
        public DbSet<Choroby> Chorobies { get; set; }
        public DbSet<Pracownicy> Pracownicies { get; set; }

    }
}
