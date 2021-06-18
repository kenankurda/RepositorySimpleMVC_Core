using Microsoft.AspNetCore.Mvc;
using RepositorySimpleMVC_Core.GenericRepository;
using RepositorySimpleMVC_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorySimpleMVC_Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _repository.SelectAll<Product>();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = new Product() { Name = product.Name, Price = product.Price };
            await _repository.CreateAsync<Product>(newProduct);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var model = await _repository.SelectById<Product>(id);
            if (model ==  null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> DeleteProduct(Product product)
        {
            var model = await _repository.SelectById<Product>(product.Id);
            if (model == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync<Product>(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Product model)
        {
            var Findmodel = await _repository.SelectById<Product>(model.Id);

            return View(Findmodel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int? id, Product model)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync<Product>(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
