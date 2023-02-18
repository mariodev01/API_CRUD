using System.ComponentModel.DataAnnotations;

namespace WebApi_Alumnos.Models.DTO
{
    public class AlumnoCreateDTO
    {
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Carrera { get; set; }
    }
}
