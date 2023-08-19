using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPhotoExpress.Model.Entity
{
    public class Register
    {
        public int ID { get; set; }
        public string InstitucionSuperior { get; set; }
        public string DireccionInstitucion { get; set; }
        public int NumeroAlumnos { get; set; }
        public DateTime HoraInicio { get; set; }
        public decimal ValorServicio
        {
            get; set;
        }
    }
}
