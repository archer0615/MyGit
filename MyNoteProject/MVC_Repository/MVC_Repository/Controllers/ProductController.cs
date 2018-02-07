using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using MVC_Repository.Models;
using System.Data.Entity;
using MVC_Repository.Models.Interface;
using MVC_Repository.Models.Repository;

namespace MVC_Repository.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Products> productRepository;
        private IRepository<Categories> categoryRepository;
        public IEnumerable<Categories> Categories { get { return categoryRepository.GetAll(); } }

        public ProductController()
        {
            this.productRepository = new GenericRepository<Products>();
            this.categoryRepository = new GenericRepository<Categories>();
        }

        public ActionResult Index()
        {
            return View(productRepository.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index");
            else
                return View(this.productRepository.Get(x => x.ProductID == id));
        }


        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products products)
        {
            if (products != null && ModelState.IsValid)
            {
                this.productRepository.Create(products);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
                return View(products);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", id);
                return View(this.productRepository.Get(x => x.ProductID == id));
            }
        }

        [HttpPost]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }


        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index");
            else
                return View(this.productRepository.Get(x => x.ProductID == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            productRepository.Delete(x => x.ProductID == id);
            return RedirectToAction("Index");
        }
    }
}