using AspNotebook.Configuration;
using AspNotebook.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspNotebook.Controllers
{
    [Route("/person/edit/{id}")]
    public class EditController : Controller
    {
        readonly ILogger<EditController> _logger;
        readonly NotebookContext _context;
        readonly IMapper _mapper;

        public EditController(ILogger<EditController> logger, NotebookContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult EditPerson(int id)
        {
            var person = _context.Persons.Where(x => x.Id == id).FirstOrDefault();

            if (person is null)
            {
                ViewBag.Error = true;
                ViewBag.Message = "Контакт не существует.";
                return View();
            }

            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPerson(int id, [FromForm] PersonPutViewModel value)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);

            if (person is null)
            {
                ViewBag.Message = $"Пользователь с id {id} не найден.";
                RedirectToAction("Error", "Home");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Error = true;
                ViewBag.Message = "Неверно заполнены поля формы.";
                return View();
            }

            if (_context.Persons.Any(x => x.Name == value.Name.Trim() && x.Id != id))
            {
                ViewBag.Error = true;
                ViewBag.Message = "Пользователь с таким именен уже существует в БД.";
                return View();
            }

            _mapper.Map(value, person);

            try
            {
                _context.Persons.Update(person);
                _context.SaveChanges();

                ViewBag.Sucess = true;
                ViewBag.Message = "Contact edited";
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.Message = ex.Message;
            }

            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }
    }
}