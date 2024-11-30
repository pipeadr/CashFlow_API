using CashFlow_API.DAL.Entities;
using CashFlow_API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace CashFlow_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : Controller
    {
        private readonly IGastoService _gastoService;
        public GastosController(IGastoService gastoService)
        {
            _gastoService = gastoService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastoAsync()
        {
            var gastos = await _gastoService.GetGastoAsync();
            if (gastos == null || !gastos.Any()) return NotFound();
            return Ok(gastos);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Gasto>> GetGastoByIdAsync(Guid id)
        {
            var gasto = await _gastoService.GetGastoByIdAsync(id);
            if (gasto == null) return NotFound();
            return Ok(gasto);
        }
        [HttpGet, ActionName("Get")]
        [Route("GetByReference/{reference}")]
        public async Task<ActionResult<Gasto>> GetGastoByReferenceAsync(string referencia)
        {
            var gasto = await _gastoService.GetGastoByReferenceAsync(referencia);
            if (gasto == null) return NotFound();
            return Ok(gasto);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Gasto>> CreateGastoAsync(Gasto gasto)
        {
            try
            {
                var newGasto = await _gastoService.CreateGastoAsync(gasto);
                if (newGasto == null) return NotFound();
                return Ok(newGasto);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", gasto.Referencia));
                return Conflict(ex.Message);

            }
        }
        [HttpPost, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<Gasto>> UpdateGastoAsync(Gasto gasto)
        {
            try
            {
                var updateGasto = await _gastoService.UpdateGastoAsync(gasto);
                if (updateGasto == null) return NotFound();
                return Ok(updateGasto);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", gasto.Referencia));
                return Conflict(ex.Message);

            }

        }
        [HttpPost, ActionName("Delete")]
        [Route("DeleteById/{id}")]
        public async Task<ActionResult<Gasto>> DeleteGastoByIdAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedGasto = await _gastoService.DeleteGastoByIdAsync(id);
            if (deletedGasto == null) return NotFound();
            return Ok(deletedGasto);

        }
        [HttpPost, ActionName("Delete")]
        [Route("DeleteByReference/{reference}")]
        public async Task<ActionResult<Gasto>> DeleteGastoByReferenceAsync(string referencia)
        {
            if (referencia == null) return BadRequest();
            var deletedGasto = await _gastoService.DeleteGastoByReferenceAsync(referencia);
            if (deletedGasto == null) return NotFound();
            return Ok(deletedGasto);

        }

    }
}
