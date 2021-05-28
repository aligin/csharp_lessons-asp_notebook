using AspNotebook.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNotebook.Controllers
{
    [Route("/person/delete/{id}")]
    public class DeleteController : Controller
    {
        readonly NotebookContext _context;

        public DeleteController(NotebookContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);

            if (person is not null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}