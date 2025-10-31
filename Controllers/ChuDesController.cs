﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using baithi2.Data;
using baithi2.Models;

namespace baithi2.Controllers
{
    public class ChuDesController : Controller
    {
        private readonly AppDbContext _context;

        public ChuDesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ChuDes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChuDe.ToListAsync());
        }

        // GET: ChuDes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe
                .FirstOrDefaultAsync(m => m.MaChuDe == id);
            if (chuDe == null)
            {
                return NotFound();
            }

            return View(chuDe);
        }

        // GET: ChuDes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChuDes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuDe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuDe);
        }

        // GET: ChuDes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe.FindAsync(id);
            if (chuDe == null)
            {
                return NotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (id != chuDe.MaChuDe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuDe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuDeExists(chuDe.MaChuDe))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chuDe);
        }

        // GET: ChuDes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuDe = await _context.ChuDe
                .FirstOrDefaultAsync(m => m.MaChuDe == id);
            if (chuDe == null)
            {
                return NotFound();
            }

            return View(chuDe);
        }

        // POST: ChuDes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);
            if (chuDe != null)
            {
                _context.ChuDe.Remove(chuDe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuDeExists(int id)
        {
            return _context.ChuDe.Any(e => e.MaChuDe == id);
        }
    }
}
