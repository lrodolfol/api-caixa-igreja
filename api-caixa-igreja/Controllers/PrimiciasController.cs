using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}
