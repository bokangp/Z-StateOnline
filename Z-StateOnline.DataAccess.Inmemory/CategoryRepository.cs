using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Z_StateOnline.Core.Models;

namespace Z_StateOnline.DataAccess.Inmemory
{
    public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;
        public CategoryRepository()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory c)
        {
            categories.Add(c);
        }

        public void Update(ProductCategory category)
        {
            ProductCategory categoryToUpdate = categories.Find(c => c.Id == category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory category = categories.Find(c => c.Id == Id);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
        public IQueryable<ProductCategory> collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = categories.Find(c => c.Id == Id);
            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Category Was not Find");
            }
        }
    }
}
