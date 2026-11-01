using BookWorm.Hub.Service;
using BookWorm.Shared.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionController(DevolucionSrv devolucionSrv) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DevolucionMdl devolucion)
        {
            await devolucionSrv.Create(devolucion);
            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] DevolucionMdl devolucion)
        {
            if (Id != devolucion.Id)
            {
                return BadRequest();
            }
            await devolucionSrv.Update(devolucion);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Lista = await devolucionSrv.Read();
            if (Lista == null || Lista.Count == 0)
            {
                return NotFound();
            }
            return Ok(Lista);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            DevolucionMdl devolucion = await devolucionSrv.ReadOne(Id);
            return Ok(devolucion);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await devolucionSrv.Delete(Id);
            return Ok();
        }
    }
}
