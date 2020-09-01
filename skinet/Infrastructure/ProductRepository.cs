
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure

{
    public class ProductRepository : IProductRepository
    {
         private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Products>> GetProducts()
        {
            var product=  await _context.Products.ToListAsync();
            return product;
        }

        public async Task<Products> GetSingleProductAsync(int id)
        {
             var product= await _context.Products.FindAsync(id);
             return product;
        }
    }
}