using AspNotebook.Configuration;
using AspNotebook.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AspNotebook.Models;

namespace AspNotebook.Controllers
{
    [Route("/person/edit/{personId}")]
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
        public IActionResult EditPerson(int personId)
        {
            var person = _context.Persons.Where(x => x.Id == personId).First();
            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPerson(int personId, string personName, string personTelephone)
        {
            var person = new Person{Id = personId, Name = personName, Telephone = personTelephone};
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChangesAsync();
    }
            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }
    }
}