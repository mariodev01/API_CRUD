using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Alumnos.Models;
using WebApi_Alumnos.Models.DTO;
using WebApi_Alumnos.Repository.IRepository;

namespace WebApi_Alumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IAlumno _alumno;

        public AlumnoController(IMapper mapper,ApplicationDbContext context,IAlumno alumno)
        {
            _mapper = mapper;
            _context = context;
            _alumno = alumno;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var alumnos = await _alumno.GetAll();
            //var alumnos = await _context.Alumnos.ToListAsync();
            return Ok(alumnos);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetId(int id)
        {
            var alumno = await _alumno.GetById(id);
            if(alumno == null)
            {
                return NotFound();
            }

            return Ok(alumno);
        }
        [HttpPost]
        public async Task<ActionResult> Post(AlumnoCreateDTO alumnoCreate)
        {
            Alumno modelo = _mapper.Map<Alumno>(alumnoCreate);
            
            await _alumno.Crear(modelo);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update( int id, [FromBody] AlumnoCreateDTO alumnoCreate)
        {
            var alumno = await _alumno.GetById(id);
            if (alumno == null)
            {
                return NotFound();
            }
            //Alumno modelo = _mapper.Map<Alumno>(alumnoCreate);
            alumno.Nombre = alumnoCreate.Nombre;
            alumno.Carrera = alumnoCreate.Carrera;
            alumno.Edad = alumnoCreate.Edad;
            await _alumno.Actualizar(alumno);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var alumno = await _alumno.GetById(id);
            if (alumno == null)
            {
                return NotFound();
            }

            await _alumno.Borrar(id);
            return NoContent();
        }

    }
}
