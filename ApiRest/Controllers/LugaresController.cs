using Core.Entities;
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
        private readonly AppDBContext _db;
        public LugaresController(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> getLugares()
        {
            var places = await _db.Lugar.ToListAsync();
            return Ok(places);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> getLugar(int id)
        {
            var place = await _db.Lugar.FindAsync(id);
            return Ok(place);   
        }
    }
}
