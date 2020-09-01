using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Products> GetSingleProductAsync(int id);
         Task<IReadOnlyList<Products>> GetProducts();
    }
}