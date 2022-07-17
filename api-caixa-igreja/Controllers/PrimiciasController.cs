using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using api_caixa_igreja.Models.Data.Dtos.Primicias;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimiciasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PrimiciasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Primicias()
        {
            List<Primicias> primicias = _context.Primicias.ToList();
            List<ReadPrimiciasDto> primiciasDto = _mapper.Map<List<ReadPrimiciasDto>>(primicias);

            return primicias == null? NotFound() : Ok(primiciasDto);
        }

        [HttpGet("{id}")]
        public IActionResult Primicias(int id)
        {
            Primicias primicia = _context.Primicias.FirstOrDefault(p => p.Id == id);
            ReadPrimiciasDto primiciasDto = _mapper.Map<ReadPrimiciasDto>(primicia);

            return primicia == null ? NotFound() : Ok(primiciasDto);
        }

        [HttpPost]
        public IActionResult Primicias(CreatePrimiciasDto primiciasDto)
        {
            try
            {
                Primicias primicias = _mapper.Map<Primicias>(primiciasDto);
                _context.Primicias.Add(primicias);
                _context.SaveChanges();

                return CreatedAtAction(nameof(primicias), new { Id = primicias.Id }, primicias);

            }
            catch (Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Primicias(int id, CreatePrimiciasDto primiciasDto)
        {
            Primicias primicias = _context.Primicias.FirstOrDefault(of => of.Id == id);
            if (primicias == null)
            {
                return NotFound();
            }

            try
            {
                primicias = _mapper.Map(primiciasDto, primicias);
                _context.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new MessageException
                {
                    Descricao = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrimicias(int id)
        {
            Primicias primicias = _context.Primicias.FirstOrDefault(of => of.Id == id);
            if (primicias == null)
            {
                return NotFound();
            }

            _context.Primicias.Remove(primicias);
            _context.SaveChanges();

            return NoContent();
        }

        /*
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Primicias.Include(p => p.Membro).Include(p => p.TipoOferta);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Primicias == null)
            {
                return NotFound();
            }

            var primicias = await _context.Primicias
                .Include(p => p.Membro)
                .Include(p => p.TipoOferta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (primicias == null)
            {
                return NotFound();
            }

            return View(primicias);
        }

        public IActionResult Create()
        {
            ViewData["IdMembro"] = new SelectList(_context.primicias, "Id", "Nome");
            ViewData["IdTipoOferta"] = new SelectList(_context.TipoOferta, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dia,Periodo,Valor,IdMembro,IdTipoOferta")] Primicias primicias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(primicias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMembro"] = new SelectList(_context.primicias, "Id", "Nome", primicias.IdMembro);
            ViewData["IdTipoOferta"] = new SelectList(_context.TipoOferta, "Id", "Descricao", primicias.IdTipoOferta);
            return View(primicias);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Primicias == null)
            {
                return NotFound();
            }

            var primicias = await _context.Primicias.FindAsync(id);
            if (primicias == null)
            {
                return NotFound();
            }
            ViewData["IdMembro"] = new SelectList(_context.primicias, "Id", "Nome", primicias.IdMembro);
            ViewData["IdTipoOferta"] = new SelectList(_context.TipoOferta, "Id", "Descricao", primicias.IdTipoOferta);
            return View(primicias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dia,Periodo,Valor,IdMembro,IdTipoOferta")] Primicias primicias)
        {
            if (id != primicias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(primicias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrimiciasExists(primicias.Id))
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
            ViewData["IdMembro"] = new SelectList(_context.primicias, "Id", "Nome", primicias.IdMembro);
            ViewData["IdTipoOferta"] = new SelectList(_context.TipoOferta, "Id", "Descricao", primicias.IdTipoOferta);
            return View(primicias);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Primicias == null)
            {
                return NotFound();
            }

            var primicias = await _context.Primicias
                .Include(p => p.Membro)
                .Include(p => p.TipoOferta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (primicias == null)
            {
                return NotFound();
            }

            return View(primicias);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Primicias == null)
            {
                return Problem("Entity set 'AppDbContext.Primicias'  is null.");
            }
            var primicias = await _context.Primicias.FindAsync(id);
            if (primicias != null)
            {
                _context.Primicias.Remove(primicias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool PrimiciasExists(int id)
        {
          return _context.Primicias.Any(e => e.Id == id);
        }
    }
}
