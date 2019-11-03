using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;
using System.Runtime.Caching;

namespace MyShop.Core
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
                products = new List<Product>();
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = products.Find(p => p.Id == product.Id);
            if (ProductToUpdate != null)
            {
                ProductToUpdate = product;
            }
            else
            {
                throw new Exception("Product no found");
            }

        }

        public Product find(string Id)
        {
            Product ProductToFind = products.Find(p => p.Id == Id);
            if (ProductToFind != null)
            {
                return ProductToFind;
            }
            else
            {
                throw new Exception("Product no found");
            }

        }


        public void DeleteProduct(Product product)
        {
            Product ProductToDelete = products.Find(p => p.Id == product.Id);
            if (ProductToDelete != null)
            {
                products.Remove(ProductToDelete);
            }
            else
            {
                throw new Exception("Product no found");
            }

        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
    }
}
