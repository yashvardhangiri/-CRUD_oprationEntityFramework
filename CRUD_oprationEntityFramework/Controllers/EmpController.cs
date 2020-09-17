using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_oprationEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_oprationEntityFramework.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _database;

        public EmpController(ApplicationDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var displayData = _database.EmployeeTable.ToList();
            return View(displayData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(NewEmpClass newEmpClassObj)
        {
            if (ModelState.IsValid) 
            {
                _database.Add(newEmpClassObj);
                await _database.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(newEmpClassObj);
        }

        public async Task<IActionResult> Edit(int? Empid)
        {
            if (Empid != null)
            {
                var GetEMployeeData = await _database.EmployeeTable.FindAsync(Empid);
                return View(GetEMployeeData);
            }
            else {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewEmpClass newEmpClassObj)
        {
            if (ModelState.IsValid)
            {
                _database.Update(newEmpClassObj);
                await _database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newEmpClassObj);
        }

        public async Task<IActionResult> Details(int? Empid)
        {
            if (Empid != null)
            {
                var GetEMployeeData = await _database.EmployeeTable.FindAsync(Empid);
                return View(GetEMployeeData);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int? Empid)
        {
            if (Empid != null)
            {
                var GetEMployeeData = await _database.EmployeeTable.FindAsync(Empid);
                return View(GetEMployeeData);
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Empid)
        {

        var GetEMployeeData = await _database.EmployeeTable.FindAsync(Empid);
            _database.EmployeeTable.Remove(GetEMployeeData);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
