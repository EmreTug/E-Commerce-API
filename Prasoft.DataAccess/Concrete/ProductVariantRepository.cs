using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class ProductVariantService
    {
        public ProductVariant createProductVariant(ProductVariant productVariant)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.ProductVariant.Add(productVariant);
                prapazdbContext.SaveChanges();
                return productVariant;
            }
        }

        public ProductVariant deleteProductVariant(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedProductVariant = getProductVariantById(id);
                prapazdbContext.Remove(deletedProductVariant);
                prapazdbContext.SaveChanges();
                return deletedProductVariant;
            }
        }

        public List<ProductVariant> getAllProductVariant(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.ProductVariant.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public ProductVariant getProductVariantById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.ProductVariant.Find(id);
            }
        }

        public ProductVariant updateProductVariant(ProductVariant productVariant)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.ProductVariant.Add(productVariant);
                prapazdbContext.SaveChanges();
                return productVariant;
            }
        }
    }
}
