using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsController()
        {
        }
        public ProductsController(Product[] products)
        {
            this.products = products;
        }

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Soda", Category = "Groceries", Price = 2 },
            new Product { Id = 2, Name = "Towel", Category = "Household", Price = 5.75M },
            new Product { Id = 3, Name = "Nerfgun", Category = "Toys", Price = 13.99M }
        };

        // The GetAllProducts method returns the entire list of products as an IEnumerable<Product> type.
        //  	/api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }


        // The GetProduct method looks up a single product by its ID.
        //  	/api/products/id
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}