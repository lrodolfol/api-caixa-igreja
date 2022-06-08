using api_caixa_igreja.Models;
using api_caixa_igreja.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembroController : ControllerBase  
    {
        private AppDbContext _context;

        public MembroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Membro()
        {
            List<Membros> membros = _context.Membros.ToList();

            if (membros == null)
            {
                return NotFound();
            }

            return Ok(membros);
        }

        [HttpGet("{id}")]
        public IActionResult Membro(int id)
        {
            Membros membro = _context.Membros.Find(id);
            if(membro == null)
            {
                return NotFound();
            }

            return Ok(membro);
        }

        [HttpPost]
        public IActionResult Membro(Membros membro)
        {
            _context.Add(membro);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
