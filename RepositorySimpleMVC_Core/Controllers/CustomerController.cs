using Microsoft.AspNetCore.Mvc;
using RepositorySimpleMVC_Core.GenericRepository;
using RepositorySimpleMVC_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorySimpleMVC_Core.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly IRepository _repository;
        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _repository.SelectAll<Customer>();
            return View(model);
        }
    }
}
