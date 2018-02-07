using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Repository.Models;
using MVC_Repository.Models.Interface;
using System.Data.Entity;
using MVC_Repository.Models.Repository;

namespace MVC_Repository.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Categories> categoryRepository;

        public CategoryController()
        {
            this.categoryRepository = new GenericRepository<Categories>();
        }
        public ActionResult Index()
        {
            var categories = this.categoryRepository.GetAll().ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.categoryRepository.Create(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var model = categoryRepository.Get(x => x.CategoryID == id);
                ViewData.Model = model;
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index");
            else
                return View(categoryRepository.Get(x => x.CategoryID == id));
        }
        [HttpPost]
        public ActionResult Edit(Categories category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.categoryRepository.Update(category);
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index");
            else
                return View(categoryRepository.Get(x => x.CategoryID == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                this.categoryRepository.Delete(x => x.CategoryID == id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }
    }
}