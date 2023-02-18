using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Alumnos.Models;
using WebApi_Alumnos.Models.DTO;

namespace WebApi_Alumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AlumnoController(IMapper mapper,ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<AlumnoDTO>>> Get()
        {
            var alumnos = await _context.Alumnos.ToListAsync();
            return Ok(_mapper.Map<List<AlumnoDTO>>(alumnos));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlumnoDTO>> GetId(int id)
        {
            var alumno = await _context.Alumnos.FirstOrDefaultAsync(a=>a.Id== id);
            if(alumno == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlumnoDTO>(alumno));
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlumnoCreateDTO alumnoCreate)
        {
            var alumnos = _mapper.Map<Alumno>(alumnoCreate);

            await _context.AddAsync(alumnos);
            await _context.SaveChangesAsync();
            return Ok(alumnos);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update( int id, [FromBody] AlumnoCreateDTO alumnoCreate)
        {
            var existeAlumno = await _context.Alumnos.AnyAsync(a => a.Id == id);

            if (!existeAlumno)
            {
                return NotFound();
            }

            var alumno = _mapper.Map<Alumno>(alumnoCreate);
            alumno.Id= id;
            _context.Update(alumno);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existeAlumno = await _context.Alumnos.AnyAsync(a => a.Id == id);
            if (!existeAlumno)
            {
                return NotFound();
            }

            _context.Remove(new Alumno { Id = id});
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
