using MVC_Repository.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MVC_Repository.Models.Repository
{
    public class GetOrderRepository<T> : IGetOrderRepository<T> where T : class
    {
        private bool disposed = false;

        public T Error(string errorMessage)
        {
            try
            {
                dynamic response = new ExpandoObject();
                response.Status = "Failure";
                response.Data = null;
                response.TimeStamp = "";
                response.ErrorMessage = errorMessage;

                T item = (T)Activator.CreateInstance(typeof(T));
                return Map(response, item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T Map(ExpandoObject source, T destination)
        {
            IDictionary<string, object> dict = source;
            var type = destination.GetType();

            foreach (var prop in type.GetProperties())
            {
                var lower = prop.Name.ToLower();
                var key = dict.Keys.SingleOrDefault(k => k.ToLower() == lower);

                if (key != null)
                {
                    prop.SetValue(destination, dict[key], null);
                }
            }
            return destination;
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }
            this.disposed = true;
        }
        #endregion

    }
}