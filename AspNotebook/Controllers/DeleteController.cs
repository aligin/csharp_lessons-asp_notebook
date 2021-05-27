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
    [Route("/person/delete/{Id}")]
    public class DeleteController : Controller
    {

        readonly ILogger<DeleteController> _logger;
        readonly NotebookContext _context;
        readonly IMapper _mapper;
        public DeleteController(ILogger<DeleteController> logger, NotebookContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult DeletePerson(int Id)
        {
            var person = _context.Persons.Where(x => x.Id == Id).First();
            _context.Persons.Remove(person);
            _context.SaveChanges();
            return Redirect("/");
        }
    }
}