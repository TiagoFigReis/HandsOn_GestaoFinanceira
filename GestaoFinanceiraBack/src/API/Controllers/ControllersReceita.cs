using Application.Exceptions;
using Application.InputModels.InputModelsReceitas;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;


namespace API.Controllers
{
    [ApiController]
    [Route("api/receita")]
    public class ReceitaController(IReceitaServices receitaServices) : ControllerBase
    {
        private readonly IReceitaServices _receitaServices = receitaServices;

        /// <summary>
        /// Get all revenues
        /// </summary>
        /// <returns>Receitas collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var receitas = await _receitaServices.GetAllAsync(User);
            return Ok(receitas);
        }

        /// <summary>
        /// Get one revenue by id
        /// </summary>
        /// /// <param name="id">Receita id</param>
        /// <returns>Receitas</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var receitas = await _receitaServices.GetByIdAsync(id, User);
            return Ok(receitas);
        }

        /// <summary>
        /// Add revenue
        /// </summary>
        /// <param name="inputModel">Receita InputModel</param>
        /// <returns>Receitas</returns>
        /// <response code="201">Created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateReceitaInputModel inputModel)
        {
            var receitas = await _receitaServices.Add(User, inputModel);
            return CreatedAtAction(nameof(GetId), new { id = receitas.Id }, receitas);
        }

        /// <summary>
        /// Updates a revenue
        /// </summary>
        /// <param name="id">Receita Id</param>
        /// <param name="inputModel">Receita InputModel</param>
        /// <returns>Receitas</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateReceitaInputModel inputModel)
        {
            var receita = await _receitaServices.Update(User, id, inputModel);
            return Ok(receita);
        }

        /// <summary>
        /// Delete a revenue
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
            await _receitaServices.Delete(User, id);
            return NoContent();
        }
    }
}