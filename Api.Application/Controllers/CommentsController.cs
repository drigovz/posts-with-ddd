using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentServices _service;

        public CommentsController(ICommentServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            try
            {
                var comments = await _service.GetAsync();
                return comments.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpGet("post/{post:int}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsInPost([BindRequired] int post)
        {
            try
            {
                var comments = await _service.GetCommentsPostAsync(post);
                return comments.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                var comment = await _service.GetByIdAsync(id);
                if (comment == null)
                    return NotFound($"Comment with id {id} not found");
                else
                    return new ObjectResult(comment);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Comment comment)
        {
            try
            {
                var result = await _service.AddAsync(comment);
                return new ObjectResult(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to add a new comment");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] Comment comment)
        {
            try
            {
                if (comment == null || id != comment.Id)
                    return BadRequest($"Comment with id {id} not found");
                else
                {
                    var result = await _service.UpdateAsync(comment);
                    return StatusCode(StatusCodes.Status200OK, $"Comment id {id} update succesfull");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to update comment");
            }
        }
    }
}