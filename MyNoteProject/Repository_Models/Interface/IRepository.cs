using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Repository_Models.Interface
{
    /// <summary>
    /// 代表一個Repository的Interface
    /// </summary>
    /// <typeparam name="T">任意model的class</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="entity">要新增的Entity</param>
        void Create(T entity);

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity。</param>
        void Delete(T entity);

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        void Update(T entity);

        /// <summary>
        /// 更新一筆資料的內容。只更新部分欄位。
        /// EX : x => { x.ColumnName1, x.Column2 }
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        /// <param name="updateProperties">需要更新的欄位。</param>
        void Update(T entity, Expression<Func<T, object>>[] updateProperties);

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        T Read(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 取得合條件的內容。可能回傳一筆或是多筆
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <param name="predicates">要取得的Where條件。可新增N個條件值</param>
        /// <returns>只要符合條件則回傳全部筆數的IQueryable。</returns>
        IQueryable<T> Reads(Expression<Func<T, bool>> predicate, params Expression<Func<T, bool>>[] predicates);

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        IQueryable<T> Reads();
    }
}
