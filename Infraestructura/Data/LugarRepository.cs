using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructura.Data
{
    public class LugarRepository : ILugarRepository
    {
        private readonly AppDBContext _db;
        public LugarRepository(AppDBContext db)
        {
            _db = db;
        }
        public async Task<Lugar> getLugarAsync(int id)
        {
           var place = await _db.Lugar.Include(p => p.Pais).
                Include(c => c.Categoria).FirstOrDefaultAsync();
            return place;
        }

        public async Task<IReadOnlyList<Lugar>> getLugaresListAsync()
        {
            var places = await _db.Lugar.Include(p => p.Pais).
                Include(c => c.Categoria).
                ToListAsync();

            return places;
        }
    }
}
