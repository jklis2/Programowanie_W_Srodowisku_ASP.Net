using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzychodniaFinal.DataAccess;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.services;

namespace PrzychodniaFinal.Controllers
{
    public class PacjencisController : Controller
    {
        private readonly PrzychodniaDBContext context;
        private readonly IPacjenciServices service;

        public PacjencisController(PrzychodniaDBContext context, IPacjenciServices service)
        {
            this.context = context;
            this.service = service;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {    
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BirthDateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var pacjenci = await service.GetPacjenci(sortOrder, searchString);

            return View(pacjenci);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await context.Pacjencis
                .FirstOrDefaultAsync(m => m.PacjenciID == id);
            if (pacjenci == null)
            {
                return NotFound();
            }

            return View(pacjenci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacjenciID,Imie,Nazwisko,Pesel,DataUrodzenia,AdresZamieszkania")] Pacjenci pacjenci)
        {
            if (ModelState.IsValid)
            {
                await service.Create(pacjenci);
                return RedirectToAction(nameof(Index));
            }
            return View(pacjenci);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await service.GetPatientById(id);
            if (pacjenci == null)
            {
                return NotFound();
            }
            return View(pacjenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacjenciID,Imie,Nazwisko,Pesel,AdresZamieszkania")] Pacjenci pacjenci)
        {
            if (id != pacjenci.PacjenciID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await service.Edit(id, pacjenci);               
                return RedirectToAction(nameof(Index));
            }
            return View(pacjenci);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacjenci = await context.Pacjencis
                .FirstOrDefaultAsync(m => m.PacjenciID == id);
            if (pacjenci == null)
            {
                return NotFound();
            }

            return View(pacjenci);
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
