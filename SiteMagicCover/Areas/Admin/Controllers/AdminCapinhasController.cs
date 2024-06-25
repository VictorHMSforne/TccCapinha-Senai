using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SiteMagicCover.Context;
using SiteMagicCover.Models;

namespace SiteMagicCover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCapinhasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminCapinhasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminCapinhas
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Capinhas.Include(c => c.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "NomeCelular")
        {
            var resultado = _context.Capinhas.Include(c => c.Categoria)
                                             .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.NomeCelular.Contains(filter));
            }

            // Utilize a propriedade correta para ordenação
            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "NomeCelular");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: Admin/AdminCapinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Capinhas == null)
            {
                return NotFound();
            }

            var capinha = await _context.Capinhas
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.CapinhaId == id);
            if (capinha == null)
            {
                return NotFound();
            }

            return View(capinha);
        }

        // GET: Admin/AdminCapinhas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminCapinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapinhaId,Marca,Modelo,NomeCelular,Preco,ImagemUrl,ImagemThumbUrl,Disponibilidade,IsPersonalizada,UserId,CategoriaId")] Capinha capinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", capinha.CategoriaId);
            return View(capinha);
        }

        // GET: Admin/AdminCapinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Capinhas == null)
            {
                return NotFound();
            }

            var capinha = await _context.Capinhas.FindAsync(id);
            if (capinha == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", capinha.CategoriaId);
            return View(capinha);
        }

        // POST: Admin/AdminCapinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapinhaId,Marca,Modelo,NomeCelular,Preco,ImagemUrl,ImagemThumbUrl,Disponibilidade,IsPersonalizada,UserId,CategoriaId")] Capinha capinha)
        {
            if (id != capinha.CapinhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapinhaExists(capinha.CapinhaId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", capinha.CategoriaId);
            return View(capinha);
        }

        // GET: Admin/AdminCapinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Capinhas == null)
            {
                return NotFound();
            }

            var capinha = await _context.Capinhas
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.CapinhaId == id);
            if (capinha == null)
            {
                return NotFound();
            }

            return View(capinha);
        }

        // POST: Admin/AdminCapinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Capinhas == null)
            {
                return Problem("Entity set 'AppDbContext.Capinhas'  is null.");
            }
            var capinha = await _context.Capinhas.FindAsync(id);
            if (capinha != null)
            {
                _context.Capinhas.Remove(capinha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapinhaExists(int id)
        {
          return _context.Capinhas.Any(e => e.CapinhaId == id);
        }
    }
}
