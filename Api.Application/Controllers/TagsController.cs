using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TagsController : ControllerBase
    {
        private readonly ITagServices _service;

        public TagsController(ITagServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAll()
        {
            try
            {
                var tags = await _service.GetAsync();
                return tags.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro when try to connect on server");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                var tag = await _service.GetByIdAsync(id);
                if (tag == null)
                    return NotFound($"Tag with id {id} not found");
                else
                    return new ObjectResult(tag);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tag tag)
        {
            try
            {
                if (tag == null)
                    return BadRequest();

                var result = await _service.AddAsync(tag);
                return new ObjectResult(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new tag");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] Tag tag)
        {
            try
            {
                if (tag == null || id != tag.Id)
                    return BadRequest($"Tag with id {id} not found");
                else
                {
                    var result = await _service.UpdateAsync(tag);
                    return StatusCode(StatusCodes.Status200OK, $"Tag id {id} update succesfull");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to update a new tag");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([BindRequired] int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Tag with id {id} not found");

                await _service.DeleteAsync(id);

                return StatusCode(StatusCodes.Status200OK, "Tag deleted succesfull");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete tag");
            }
        }
    }
}