using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.Services
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, T entity);
        Task DeleteAsync(string url);
    }
}
