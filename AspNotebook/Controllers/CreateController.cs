using AspNotebook.Configuration;
using AspNotebook.Models;
using AspNotebook.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspNotebook.Controllers
{
    [Route("/person/create")]
    public class CreateController : Controller
    {
        readonly ILogger<CreateController> _logger;
        readonly NotebookContext _context;
        readonly IMapper _mapper;

        public CreateController(ILogger<CreateController> logger, NotebookContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            var model = new PersonPostViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromForm] PersonPostViewModel value)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = true;
                ViewBag.Message = "Неверно заполнены поля формы.";
                return View(value);
            }

            if (_context.Persons.Any(x => x.Name == value.Name.Trim()))
            {
                ViewBag.Error = true;
                ViewBag.Message = "Пользователь с таким именем уже существует в БД.";
                return View(value);
            }

            var person = _mapper.Map<Person>(value);

            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();

                ViewBag.Sucess = true;
                ViewBag.Message = "Contact created";
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}