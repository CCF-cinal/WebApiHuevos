using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHuevos.Entidades;

namespace WebApiHuevos.Controllers
{
    [ApiController]
    [Route("huevos")]
    public class HuevosController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public HuevosController (ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Huevo>>> GetAll()
        {
            return await dbContext.Huevos.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Huevo>> GetById(int id)
        {
            return await dbContext.Huevos.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Huevo huevo)
        {
            var existeEncargado = await dbContext.Encargados.AnyAsync(x => x.Id == huevo.EncargadoId);

            if (!existeEncargado)
            {
                return BadRequest($"No existe el encargado con el id: {huevo.EncargadoId}");
            }
            dbContext.Add(huevo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Huevo huevo,int id)
        {
            var exist = await dbContext.Huevos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El huevo especificado no existe");
            }
            if (huevo.Id != id)
            {
                return BadRequest("El id del huevo no coincide con el establecido.");
            }
            dbContext.Update(huevo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Huevos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado.");
            }
            dbContext.Remove(new Huevo { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
