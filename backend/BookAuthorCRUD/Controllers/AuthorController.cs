using BookAuthorCRUD.Application.Feature.Author.Command.Create;
using BookAuthorCRUD.Application.Feature.Author.Command.Delete;
using BookAuthorCRUD.Application.Feature.Author.Command.Update;
using BookAuthorCRUD.Application.Feature.Author.Queries.GetAll;
using BookAuthorCRUD.Application.Feature.Author.Queries.GetBooks;
using BookAuthorCRUD.Application.Feature.Author.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorCRUD.API.Controllers
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAuthorQuery()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery(id)));
        }

        [HttpGet("books/{authorId:guid}")]
        public async Task<IActionResult> GetBooksByAuthorId(Guid authorId)
        {
            return Ok(await Mediator.Send(new GetBooksByAuthorIdQuery(authorId)));
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAuthor(Guid id,UpdateAuthorCommand command)
        {

            if (command.Id != id)
            {
                return BadRequest("The Id in the Entity doesn't match with the provide in the URL");
            }

            var response = await Mediator.Send(command);

            return response.Match<IActionResult>(
                (succ) =>
                {
                    return NoContent();
                },
                err =>
                {
                    return BadRequest(err);
                }
            );
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await Mediator.Send(new DeleteAuthorCommand(id));

            return NoContent();
        }
    }
}
