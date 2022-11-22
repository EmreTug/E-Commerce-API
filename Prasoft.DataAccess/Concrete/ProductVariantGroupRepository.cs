using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class ProductVariantGroupService
    {
        public ProductVariantGroup createProductVariantGroup(ProductVariantGroup productVariantGroup)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.ProductVariantGroup.Add(productVariantGroup);
                prapazdbContext.SaveChanges();
                return productVariantGroup;
            }
        }

        public ProductVariantGroup deleteProductVariantGroup(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedProductVariantGroup = getProductVariantGroupById(id);
                foreach (var orderLine
                    in deletedProductVariantGroup.OrderLine)
                {
                    prapazdbContext.OrderLine.Remove(orderLine);
                }
                foreach (var variantPicture
                  in deletedProductVariantGroup.VariantPicture)
                {
                    prapazdbContext.VariantPicture.Remove(variantPicture);
                }
                var deletedProductVariant = prapazdbContext.ProductVariant.FirstOrDefault(x => x.ProductVariantGroupId == id);
                prapazdbContext.Remove(deletedProductVariantGroup);
                prapazdbContext.SaveChanges();
                return deletedProductVariantGroup;
            }
        }

        public List<ProductVariantGroup> getAllProductVariantGroup(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.ProductVariantGroup.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public ProductVariantGroup getProductVariantGroupById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.ProductVariantGroup.Find(id);
            }
        }

        public List<ProductVariantGroup> getProductVariantGroupByProductId(long id)
        {
            
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.ProductVariantGroup.Where(x => x.ProductId == id).ToList();
            }

        }

        public ProductVariantGroup updateProductVariantGroup(ProductVariantGroup productVariantGroup)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.ProductVariantGroup.Add(productVariantGroup);
                prapazdbContext.SaveChanges();
                return productVariantGroup;
            }
        }
    }
}
