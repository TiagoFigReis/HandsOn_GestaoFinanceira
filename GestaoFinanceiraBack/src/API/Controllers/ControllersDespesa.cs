using Application.InputModels.InputModelsDespesas;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/despesa")]
    public class DespesaController(IDespesaServices despesaServices) : ControllerBase
    {
        private readonly IDespesaServices _despesaServices = despesaServices;

        /// <summary>
        /// Get all expenses
        /// </summary>
        /// <returns>Despesas collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var receitas = await _despesaServices.GetAllAsync(User);
            return Ok(receitas);
        }

        /// <summary>
        /// Get one expense by id
        /// </summary>
        /// /// <param name="id">Despesa id</param>
        /// <returns>Despesa</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var receitas = await _despesaServices.GetByIdAsync(id, User);
            return Ok(receitas);
        }

        /// <summary>
        /// Add expense
        /// </summary>
        /// <param name="inputModel">Despesa InputModel</param>
        /// <returns>Despesa</returns>
        /// <response code="201">Created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDespesaInputModel inputModel)
        {
            var receitas = await _despesaServices.Add(User, inputModel);
            return CreatedAtAction(nameof(GetId), new { id = receitas.Id }, receitas);
        }

        /// <summary>
        /// Updates a expense
        /// </summary>
        /// <param name="id">Despesa Id</param>
        /// <param name="inputModel">Despesa InputModel</param>
        /// <returns>Despesa</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDespesaInputModel inputModel)
        {
            var receita = await _despesaServices.Update(User, id, inputModel);
            return Ok(receita);
        }

        /// <summary>
        /// Delete a expense
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _despesaServices.Delete(User, id);
            return NoContent();
        }
    }
}