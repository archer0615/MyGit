using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Repository.Models.Interface
{
    public interface IGetOrderRepository<T> : IDisposable where T : class
    {
        T Error(string errorMessage);
    }
}