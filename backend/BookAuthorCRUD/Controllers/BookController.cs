using BookAuthorCRUD.Application.Feature.Book.Command.Create;
using BookAuthorCRUD.Application.Feature.Book.Command.Delete;
using BookAuthorCRUD.Application.Feature.Book.Command.Update;
using BookAuthorCRUD.Application.Feature.Book.Query.GetAll;
using BookAuthorCRUD.Application.Feature.Book.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorCRUD.API.Controllers
{
    [ApiController]
    public class BookController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBook(string? title = null)
        {
            var response = await Mediator.Send(new GetAllBookQuery());

            return Ok(
                response.Where(x => title == null || x.Title.ToLower().Contains(title.ToLower()))
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id) =>
            Ok(await Mediator.Send(new GetBookByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            var result = await Mediator.Send(command);

            return result.Match<IActionResult>(
                success =>
                {
                    return Created(nameof(GetAllBook), success);
                },
                error =>
                {
                    return BadRequest(error);
                }
            );
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest("The Id in the Entity doesn't match with the provide in the URL");
            }

            var result = await Mediator.Send(command);

            return result.Match<IActionResult>(
                Succ =>
                {
                    return NoContent();
                },
                error =>
                {
                    return BadRequest(error);
                }
            );
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await Mediator.Send(new DeleteBookCommand(id));

            return NoContent();
        }
    }
}
