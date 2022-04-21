using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Services
{
    public interface IPracownicyServices
    {
        public Task<List<Pracownicy>> GetEmployees(string sortOrder, string searchString);
        public Task<Pacjenci> GetEmployeeById(int? id);
        public Task Delete(int id);
        public Task Edit(int id, Pracownicy pracownicy);
        public Task Create([Bind("PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu")] Pracownicy pracownicy);

    }
    public class PracownicyService : IPracownicyServices
    {
        private readonly PrzychodniaDBContext context;

        public PracownicyService(PrzychodniaDBContext context)
        {
            this.context = context;
        }

        public async Task Create([Bind(new[] { "PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu" })] Pracownicy pracownicy)
        {
            context.Add(pracownicy);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pracownicy = await context.Pracownicies.FindAsync(id);
            context.Pracownicies.Remove(pracownicy);
            await context.SaveChangesAsync();
        }

        public async Task Edit(int id, Pracownicy pracownicy)
        {
            context.Update(pracownicy);
            await context.SaveChangesAsync();
        }

        public async Task<Pacjenci> GetEmployeeById(int? id)
        {
            return await context.Pacjencis.FindAsync(id);
        }

        public async Task<List<Pracownicy>> GetEmployees(string sortOrder, string searchString)
        {
            var pracownicy = await context.Pracownicies.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                pracownicy = pracownicy.Where(s => s.Imie.Contains(searchString)
                                                               || s.Nazwisko.Contains(searchString)
                                                               || s.Pesel.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    pracownicy = pracownicy.OrderByDescending(s => s.Nazwisko).ToList();
                    break;
                case "HireDate":
                    pracownicy = pracownicy.OrderBy(s => s.DataZatrudnienia).ToList();
                    break;
                case "EndDate":
                    pracownicy = pracownicy.OrderBy(s => s.KoniecKontraktu).ToList();
                    break;
                case "hiredate_desc":
                    pracownicy = pracownicy.OrderByDescending(s => s.DataZatrudnienia).ToList();
                    break;
                case "enddate_desc":
                    pracownicy = pracownicy.OrderByDescending(s => s.KoniecKontraktu).ToList();
                    break;
                default:
                    pracownicy = pracownicy.OrderBy(s => s.Nazwisko).ToList();
                    break;
            }

            return pracownicy.ToList();
        }

        public static bool IsPracownikValid(Pracownicy pracownicy)
        {
            if (pracownicy == null) return false;

            if (pracownicy.Pesel == null) return false;
            if (pracownicy.Pesel.Length != 11) return false;

            if (pracownicy.Imie == null) return false;
            if (pracownicy.Imie == "") return false;

            if (pracownicy.Nazwisko == null) return false;
            if (pracownicy.Nazwisko == "") return false;

            return true;
        }
    }

}
