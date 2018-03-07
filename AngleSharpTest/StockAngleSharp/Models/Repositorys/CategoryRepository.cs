﻿using StockAngleSharp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAngleSharp.Models.Repositorys
{
    public class CategoryRepository : GenericRepository<T_Category>
    {
        public string GetCategoryName(int id)
        {
            return this._context.Set<T_Category>().Find(id).Catetory_Name;
        }
    }
}
