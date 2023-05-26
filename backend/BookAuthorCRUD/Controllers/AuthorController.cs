using BookAuthorCRUD.Application.Feature.Author.Command.Create;
using BookAuthorCRUD.Application.Feature.Author.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorCRUD.API.Controllers
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            var response = await Mediator.Send(command);

            return response.Match<IActionResult>(
                succ =>
                {
                    return Created(nameof(GetById), succ);
                },
                err =>
                {
                    return BadRequest(err);
                }
            );
        }
    }
}
