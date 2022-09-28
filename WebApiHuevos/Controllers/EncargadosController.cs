using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHuevos.Entidades;


namespace WebApiHuevos.Controllers
{
    [ApiController]
    [Route("encargados")]
    public class EncargadosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EncargadosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [HttpGet("listado")]
        [HttpGet("/listado")]
        public async Task<ActionResult<List<Encargado>>> Get()
        {
            return await dbContext.Encargados.Include(x=>x.huevos).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Encargado>> PrimerAutor([FromHeader] int valor, [FromQuery] string encargado, [FromQuery] int encargadoId)
        {
            return await dbContext.Encargados.FirstOrDefaultAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Encargado>> Get(int id)
        {
            var alumno= await dbContext.Encargados.FirstOrDefaultAsync(x => x.Id == id);
            if (alumno == null)
            {
                return BadRequest();
            }
            return alumno;
        }
        [HttpGet("{nombre:string}")]
        public async Task<ActionResult<Encargado>> Get([FromRoute]string nombre)
        {
            var alumno = await dbContext.Encargados.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if (alumno == null)
            {
                return BadRequest();
            }
            return alumno;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Encargado encargado)
        {
            dbContext.Add(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Encargado encargado, int id)
        {
            if (encargado.Id != id)
            {
                return BadRequest("El id del encargado no coincide con el establecido en la url.");
            }
            dbContext.Update(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int})")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Encargados.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Encargado() { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
