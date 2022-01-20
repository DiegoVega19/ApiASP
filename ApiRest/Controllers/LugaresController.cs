using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugaresController : ControllerBase
    {
        private readonly ILugarRepository _repo;

        public LugaresController(ILugarRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> getLugares()
        {
            var places = await _repo.getLugaresListAsync();
            return Ok(places);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> getLugar(int id)
        {
            var place = await _repo.getLugarAsync(id);
            return Ok(place);   
        }
    }
}
