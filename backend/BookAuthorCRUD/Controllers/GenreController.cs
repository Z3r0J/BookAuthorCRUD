
using BookAuthorCRUD.Application.Feature.Genre.Command.Create;
using BookAuthorCRUD.Application.Feature.Genre.Command.Delete;
using BookAuthorCRUD.Application.Feature.Genre.Command.Update;
using BookAuthorCRUD.Application.Feature.Genre.Query.GetAll;
using BookAuthorCRUD.Application.Feature.Genre.Query.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorCRUD.API.Controllers
{
    public class GenreController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGenre() =>
            Ok(await Mediator.Send(new GetAllGenreQuery()));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetGenreById(Guid id) =>
            Ok(await Mediator.Send(new GetGenreByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreCommand command)
        {
            var result = await Mediator.Send(command);

            return result.Match<IActionResult>(
                success =>
                {
                    return Created(nameof(GetAllGenre), success);
                },
                error =>
                {
                    return BadRequest(error);
                }
            );
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateGenre(Guid id, UpdateGenreCommand command)
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

        public async Task<IActionResult> DeleteGenre(Guid id) {

            await Mediator.Send(new DeleteGenreCommand(id));

            return NoContent();
        
        }
    }
}
