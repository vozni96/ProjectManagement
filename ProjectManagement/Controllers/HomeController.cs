using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly BoardService _boardService;

        public HomeController(BoardService boardService)
        {
            _boardService = boardService;
        }

        public IActionResult Index()
        {
            var model = _boardService.ListBoard();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewBoard viewModel)
        {
            _boardService.AddBoard(viewModel);
            
            return RedirectToAction(nameof(Index));
        }
  
    }
}