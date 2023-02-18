using System.ComponentModel.DataAnnotations;

namespace WebApi_Alumnos.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Carrera { get; set; }

    }
}
