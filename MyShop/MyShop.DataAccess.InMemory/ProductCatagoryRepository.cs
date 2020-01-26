using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCatagoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatagory> productsCatagory;

        public ProductCatagoryRepository()
        {
            productsCatagory = cache["productsCatagory"] as List<ProductCatagory>;
            if (productsCatagory == null)
                productsCatagory = new List<ProductCatagory>();

        }

        public void Commit()
        {
            cache["productsCatagory"] = productsCatagory;
        }

        public void Insert(ProductCatagory p)
        {
            productsCatagory.Add(p);
        }

        public void Update(ProductCatagory productCatagory)
        {
            ProductCatagory productCatagoryToUpdate = productsCatagory.Find(p => p.Id == productCatagory.Id);
            if (productCatagoryToUpdate != null)
            {
                productCatagoryToUpdate = productCatagory;
            }
            else
                throw new Exception("productCatagory not found");
        }

        public ProductCatagory Find(string Id)
        {
            ProductCatagory Catagory = productsCatagory.Find(p => p.Id == Id);
            if (Catagory != null)
            {
                return Catagory;
            }
            else
                throw new Exception("productCatagory not found");
        }

        public IQueryable<ProductCatagory> Collection()
        {
            return productsCatagory.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCatagory productCatagoryToDelete = productsCatagory.Find(p => p.Id == Id);
            if (productCatagoryToDelete != null)
            {
                productsCatagory.Remove(productCatagoryToDelete);
            }
            else
                throw new Exception("productCatagory not found");
        }
    }
}
