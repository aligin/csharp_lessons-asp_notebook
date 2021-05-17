using AspNotebook.Configuration;
using AspNotebook.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AspNotebook.Controllers
{
    [Route("/home")]
    [Route("/")]
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly NotebookContext _context;
        readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, NotebookContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var people = _context.Persons.ToList();

            var model = _mapper.Map<IEnumerable<PersonViewModel>>(people);

            return View(model);
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("error")]
        public IActionResult Error()
        {
            var model = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            ViewData["Title"] = "miiiiiiooouuu";
            return View(model);
        }
    }
}
