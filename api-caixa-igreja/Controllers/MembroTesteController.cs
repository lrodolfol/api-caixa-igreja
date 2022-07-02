using api_caixa_igreja.Models.Data.Dtos.Membros;
using api_caixa_igreja.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_caixa_igreja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembroTesteController : ControllerBase
    {
        public static List<MembroTeste> _membros = new List<MembroTeste>();
        private IMapper _mapper;
        private static int _id = 0;

        public MembroTesteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Membros(MembroTeste newMembro)
        {
            _id++;

            MembroTeste membro = new MembroTeste();
            membro.Id = _id;
            membro.name = newMembro.name;
            _membros.Add(membro);
                        
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Membros(int id)
        {
            var membro = _membros.Find(m => m.Id == id);

            return membro != null ? Ok(membro) : NotFound();
        }

        [HttpGet]
        public IActionResult Membros()
        {
            return Ok(_membros);
        }
    }
}
