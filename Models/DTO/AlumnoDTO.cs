using System.ComponentModel.DataAnnotations;

namespace WebApi_Alumnos.Models.DTO
{
    public class AlumnoDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Carrera { get; set; }
    }
}
