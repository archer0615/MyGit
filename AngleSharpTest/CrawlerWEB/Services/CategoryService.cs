using CrawlerWEB.ViewModels;
using StockAngleSharp.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerWEB.Services
{
    public class CategoryService
    {
        public List<CategoryViewModel> GetAllCategory()
        {
            List<CategoryViewModel> results = new List<CategoryViewModel>();
            CategoryRepository categoryrepository = new CategoryRepository();
            var dataList = categoryrepository.GetAll();
            foreach (var item in dataList)
            {
                results.Add(new CategoryViewModel()
                {
                    CategoryID = item.Catetory_ID,
                    CategoryName = item.Catetory_Name,
                });
            }
            return results;
        }
    }
}