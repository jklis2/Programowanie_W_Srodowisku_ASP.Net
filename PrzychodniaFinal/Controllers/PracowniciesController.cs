using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.Services;

namespace PrzychodniaFinal.Controllers
{
    public class PracowniciesController : Controller
    {
        private readonly PrzychodniaDBContext context;
        private readonly IPracownicyServices service;

        public PracowniciesController(PrzychodniaDBContext context, IPracownicyServices service)
        {
            this.service = service;
            this.context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.HireDateSort = sortOrder == "HireDate" ? "hiredate_desc" : "HireDate";
            ViewBag.EndDateSort = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";

            var pracownicy = await service.GetEmployees(sortOrder, searchString);

            return View(pracownicy);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await context.Pracownicies
                .FirstOrDefaultAsync(m => m.PracownicyID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                await service.Create(pracownicy);
                return RedirectToAction(nameof(Index));
            }
            return View(pracownicy);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await context.Pracownicies.FindAsync(id);
            if (pracownicy == null)
            {
                return NotFound();
            }
            return View(pracownicy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracownicyID,Imie,Nazwisko,Pesel,AdresZamieszkania,DataZatrudnienia,KoniecKontraktu")] Pracownicy pracownicy)
        {
            if (id != pracownicy.PracownicyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await service.Edit(id, pracownicy);
                return RedirectToAction(nameof(Index));
            }
            return View(pracownicy);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await context.Pracownicies
                .FirstOrDefaultAsync(m => m.PracownicyID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}