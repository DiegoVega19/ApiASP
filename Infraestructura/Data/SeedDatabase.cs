using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructura.Data
{
    public class SeedDatabase
    {
        public static async Task seedAsync(AppDBContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Pais.Any())
                {
                    var paisData = File.ReadAllText("../Infraestructura/Seeders/paises.json");
                    var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);
                    foreach (var pais in paises) { 
                        await context.Pais.AddAsync(pais);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Categoria.Any())
                {
                    var CaterogiaData = File.ReadAllText("../Infraestructura/Seeders/categorias.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(CaterogiaData);
                    foreach (var item in categorias)
                    {
                        object p = await context.Categoria.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Lugar.Any())
                {
                    var LugarData = File.ReadAllText("../Infraestructura/Seeders/lugares.json");
                    var lugares = JsonSerializer.Deserialize<List<Lugar>>(LugarData);
                    foreach (var item in lugares)
                    {
                        object p = await context.Lugar.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedDatabase>();
                    logger.LogError(ex.Message);

            }
        }
    }
}
