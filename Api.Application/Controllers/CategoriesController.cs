using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            try
            {
                var categories = await _service.GetAsync();
                return categories.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                var category = await _service.GetByIdAsync(id);
                if (category == null)
                    return NotFound($"Category with id {id} not found");
                else
                    return new ObjectResult(category);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            try
            {
                var result = await _service.AddAsync(category);
                return new ObjectResult(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new category");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] Category category)
        {
            try
            {
                if (category == null || id != category.Id)
                    return BadRequest($"Category with id {id} not found");
                else
                {
                    var result = await _service.UpdateAsync(category);
                    return StatusCode(StatusCodes.Status200OK, $"Category id {id} update succesfull");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to update category");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([BindRequired] int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Category with id {id} not found");

                await _service.DeleteAsync(id);

                return StatusCode(StatusCodes.Status200OK, "Category deleted succesfull");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete category");
            }
        }
    }
}