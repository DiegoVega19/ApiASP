using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string GastoAproximado { get; set; }

        public string ImagenUrl { get; set; }

        public int PaisID { get; set; }
        
        [ForeignKey("PaisID")]

        public Pais Pais { get; set; }

        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public Categoria Categoria { get; set; }
    }
}
