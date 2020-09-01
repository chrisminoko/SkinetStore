using Core;
using Core.Entities;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("API/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult <List<Products>>> GetProducts()
        {
        var products= await _context.Products.ToListAsync();
        return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult <Products>>  GetSingleProduct(int id)
        {
            var product= await _context.Products.FindAsync(id);
            try
            {
                if(product==null)
                {
               return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex )
            {
            return BadRequest(ex);
            }
        }
    }

}