using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly BoardService _boardService;
        public BoardController(BoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost("movecard")]
        public IActionResult MoveCard([FromBody] MoveCardCommand command)
        {
            return Ok(new
            {
                Moved = true
            });
        }
    }
}