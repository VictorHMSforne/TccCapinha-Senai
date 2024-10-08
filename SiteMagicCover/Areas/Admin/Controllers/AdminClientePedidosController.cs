﻿using System;
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
using SiteMagicCover.ViewModels;

namespace SiteMagicCover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminClientePedidosController : Controller
    {
        private readonly AppDbContext _context;

        public AdminClientePedidosController(AppDbContext context)
        {
            _context = context;
        }

        

        // GET: Admin/AdminClientePedidos
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.ClientePedidos.Include(c => c.Capinha).Include(c => c.Cliente);
        //    return View(await appDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Cliente.Nome")
        {
            var resultado = _context.ClientePedidos
                                    .Include(p => p.Cliente)  // Incluindo Cliente para poder usar na ordenação
                                    .Include(p => p.Capinha)  // Incluindo Capinha para mostrar a marca
                                    .AsNoTracking()
                                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Cliente.Nome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Cliente.Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }


        // GET: Admin/AdminClientePedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientePedidos == null)
            {
                return NotFound();
            }

            var clientePedido = await _context.ClientePedidos
                .Include(c => c.Capinha)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ClientePedidoId == id);
            if (clientePedido == null)
            {
                return NotFound();
            }

            return View(clientePedido);
        }

        // GET: Admin/AdminClientePedidos/Create
        public IActionResult Create()
        {
            ViewData["CapinhaId"] = new SelectList(_context.Capinhas, "CapinhaId", "Marca");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId"); // Alterado para exibir o ID do cliente
            return View();
        }

        // POST: Admin/AdminClientePedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientePedidoId,ClienteId,CapinhaId,Preco,Quantidade,PedidoEnviado,PedidoEntregueEm")] ClientePedido clientePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapinhaId"] = new SelectList(_context.Capinhas, "CapinhaId", "Marca", clientePedido.CapinhaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clientePedido.ClienteId); // Alterado para exibir o ID do cliente
            return View(clientePedido);
        }

        // GET: Admin/AdminClientePedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientePedidos == null)
            {
                return NotFound();
            }

            var clientePedido = await _context.ClientePedidos.FindAsync(id);
            if (clientePedido == null)
            {
                return NotFound();
            }
            ViewData["CapinhaId"] = new SelectList(_context.Capinhas, "CapinhaId", "Marca", clientePedido.CapinhaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clientePedido.ClienteId); // Alterado para exibir o ID do cliente
            return View(clientePedido);
        }

        // POST: Admin/AdminClientePedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientePedidoId,ClienteId,CapinhaId,Preco,Quantidade,PedidoEnviado,PedidoEntregueEm")] ClientePedido clientePedido)
        {
            if (id != clientePedido.ClientePedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientePedidoExists(clientePedido.ClientePedidoId))
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
            ViewData["CapinhaId"] = new SelectList(_context.Capinhas, "CapinhaId", "Marca", clientePedido.CapinhaId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", clientePedido.ClienteId); // Alterado para exibir o ID do cliente
            return View(clientePedido);
        }

        // GET: Admin/AdminClientePedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientePedidos == null)
            {
                return NotFound();
            }

            var clientePedido = await _context.ClientePedidos
                .Include(c => c.Capinha)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ClientePedidoId == id);
            if (clientePedido == null)
            {
                return NotFound();
            }

            return View(clientePedido);
        }

        // POST: Admin/AdminClientePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientePedidos == null)
            {
                return Problem("Entity set 'AppDbContext.ClientePedidos'  is null.");
            }
            var clientePedido = await _context.ClientePedidos.FindAsync(id);
            if (clientePedido != null)
            {
                _context.ClientePedidos.Remove(clientePedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientePedidoExists(int id)
        {
          return _context.ClientePedidos.Any(e => e.ClientePedidoId == id);
        }
    }
}
