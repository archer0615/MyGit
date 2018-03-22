using CrawlerDAL.ViewModels;
using Repository;
using Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Service
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
        public CategoryStockViewModel GetStockByCategory(int categoryId)
        {

            StockRepository stockRepository = new StockRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            var dataList = stockRepository.GetStockByCategory(categoryId);

            CategoryStockViewModel results = new CategoryStockViewModel()
            {
                CategoryID = categoryId,
                CategoryName = categoryRepository.GetCategoryName(categoryId),
                StockList = ConvertStockListViewModel(dataList)
            };

            return results;
        }
        private List<StockViewModel> ConvertStockListViewModel(IQueryable<T_Stock> dataList)
        {
            List<StockViewModel> results = new List<StockViewModel>();

            foreach (var item in dataList)
            {
                results.Add(new StockViewModel()
                {
                    StockID = item.Stock_ID,
                    StockName = item.Stock_Name,
                    StockURL = item.Stock_Url,
                    CategoryID = item.Stock_Catetory_ID
                });
            }

            return results;
        }
    }
}
