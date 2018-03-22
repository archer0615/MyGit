using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public class StockRepository : GenericRepository<T_Stock>
    {
        public IQueryable<T_Stock> GetStockByCategory(int id)
        {
            return this._context.Set<T_Stock>().Where(x => x.Stock_Catetory_ID.Equals(id));
        }
    }
}
