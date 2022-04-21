using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;

namespace PrzychodniaFinal.services
{
    public interface IPacjenciServices
    {
        public Task<List<Pacjenci>> GetPacjenci(string sortOrder, string searchString);
        public Task<Pacjenci> GetPatientById(int? id);
        public Task Delete(int id);
        public Task Edit(int id, Pacjenci pacjenci);
        public Task Create([Bind("PacjenciID,Imie,Nazwisko,Pesel,DataUrodzenia,AdresZamieszkania")] Pacjenci pacjenci);

    }
    public class PacjenciService : IPacjenciServices
    {
        private readonly PrzychodniaDBContext context;
        public PacjenciService(PrzychodniaDBContext context)
        {
            this.context = context;
        }

        public async Task Create([Bind("PacjenciID,Imie,Nazwisko,Pesel,DataUrodzenia,AdresZamieszkania")] Pacjenci pacjenci)
        {
                context.Add(pacjenci);
                await context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var pacjenci = await context.Pacjencis.FindAsync(id);
            context.Pacjencis.Remove(pacjenci);
            await context.SaveChangesAsync();
        }

        public async Task Edit(int id, Pacjenci pacjenci)
        {
                context.Update(pacjenci);
                await context.SaveChangesAsync();
        }
        public async Task<Pacjenci> GetPatientById(int? id)
        {
            return await context.Pacjencis.FindAsync(id);
        }
        public async Task<List<Pacjenci>> GetPacjenci(string sortOrder, string searchString)
        {
            var pacjenci = await context.Pacjencis.ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                pacjenci = pacjenci.Where(s => s.Imie.Contains(searchString)
                                                               || s.Nazwisko.Contains(searchString)
                                                               || s.Pesel.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    pacjenci = pacjenci.OrderByDescending(s => s.Nazwisko).ToList();
                    break;
                case "Date":
                    pacjenci = pacjenci.OrderBy(s => s.DataUrodzenia).ToList();
                    break;
                case "date_desc":
                    pacjenci = pacjenci.OrderByDescending(s => s.DataUrodzenia).ToList();
                    break;
                default:
                    pacjenci = pacjenci.OrderBy(s => s.Nazwisko).ToList();
                    break;
            }

            return pacjenci.ToList();
        }

        public static bool IsPacjentValid(Pacjenci pacjenci)
        {
            if (pacjenci.Pesel == null) return false;
            if (pacjenci.Pesel.Length != 11) return false;

            if (pacjenci.Imie == null) return false;
            if (pacjenci.Imie == "") return false;

            if (pacjenci.Nazwisko == null) return false;
            if (pacjenci.Nazwisko == "") return false;

            return true;
        }
    }
}
