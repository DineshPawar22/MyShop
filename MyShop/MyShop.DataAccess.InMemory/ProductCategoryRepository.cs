using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;
using System.Runtime.Caching;


namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> ProductCategories = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            ProductCategories = cache["ProductCategories"] as List<ProductCategory>;
            if (ProductCategories == null)
                ProductCategories = new List<ProductCategory>();
        }

        public void Commit()
        {
            cache["ProductCategories"] = ProductCategories;
        }

        public void Insert(ProductCategory p)
        {
            ProductCategories.Add(p);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory ProductCategoryToUpdate = ProductCategories.Find(p => p.Id == ProductCategory.Id);
            if (ProductCategoryToUpdate != null)
            {
                ProductCategoryToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("Product Category no found");
            }

        }

        public ProductCategory find(string Id)
        {
            ProductCategory ProductCategoryToFind = ProductCategories.Find(p => p.Id == Id);
            if (ProductCategoryToFind != null)
            {
                return ProductCategoryToFind;
            }
            else
            {
                throw new Exception("Product Category no found");
            }

        }


        public void DeleteProductCategory(ProductCategory productCategory)
        {
            ProductCategory productCategoryToDelete = ProductCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToDelete != null)
            {
                ProductCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category no found");
            }

        }

        public IQueryable<ProductCategory> Collection()
        {
            return ProductCategories.AsQueryable();
        }
    }
}
