using DataContext.DataContext;
using DataContext.Models;
using DataContext.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_With_Pagination.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_CRUD_Pagination.Controllers
{
    public class ProductController : Controller
    {
        EFDataContext _dbContext = new EFDataContext();
        public IActionResult Index(int? pageNo)
        {
            int pageSize = 10;
            List<Product> products = _dbContext.Products.Include(p => p.CategoryInfo).ToList();

            return View(PagingList<Product>.CreateAsync(products.AsQueryable<Product>(), pageNo ?? 1, pageSize));
        }
        public IActionResult Create()
        {
            this.GetModelData();
            return View();
        }

        private void GetModelData()
        {
            ViewBag.Categories = this._dbContext.Categories.ToList();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
           //if (ModelState.IsValid)
            //{
            _dbContext.Products.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            //}
            //this.GetModelData();
            //return View("Index");
        }
        public IActionResult Edit(int id)
        {
            Product data = this._dbContext.Products.Include(p=>p.CategoryInfo).Where(p => p.ProductId == id).FirstOrDefault();
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductId = data.ProductId;
            productViewModel.ProductName = data.ProductName;
            productViewModel.CategoryId = data.CategoryId;
            productViewModel.CategoryName = data.CategoryName;
            productViewModel.CategoryInfo = data.CategoryInfo;
            this.GetModelData();
            return View("Update", data);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {

            //if (ModelState.IsValid)
            //{
            _dbContext.Products.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            //}
            //this.GetModelData();
            //return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            Product data = this._dbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (data != null)
            {
                _dbContext.Products.Remove(data);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
