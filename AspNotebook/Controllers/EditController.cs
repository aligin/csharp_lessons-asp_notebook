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
    [Route("/person/edit/{Id}")]
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
        public IActionResult EditPerson(int Id)
        {
            var person = _context.Persons.Where(x => x.Id == Id).First();
            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPerson([Bind("Id,Name,Telephone")] Person person)
        {
            try {
                _context.Update(person);
                _context.SaveChanges();
                
                ViewBag.Sucess = true;
                ViewBag.Message = "Contact edited";

            }
            catch (System.Exception ex) {
                ViewBag.Error = true;
                ViewBag.Message = ex.Message;
            }

            var model = _mapper.Map<PersonViewModel>(person);
            return View(model);
        }
    }
}