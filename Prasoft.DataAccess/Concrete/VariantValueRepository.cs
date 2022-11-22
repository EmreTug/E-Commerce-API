using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class VariantValueService
    {
        public VariantValue createVariantValue(VariantValue variantValue)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantValue.Add(variantValue);
                prapazdbContext.SaveChanges();
                return variantValue;
            }
        }

        public VariantValue deleteVariantValue(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedVariantValue = getVariantValueById(id);
                foreach (var productVariant
           in deletedVariantValue.ProductVariant)
                {
                    prapazdbContext.ProductVariant.Remove(productVariant);
                }
                prapazdbContext.VariantValue.Remove(deletedVariantValue);
                prapazdbContext.SaveChanges();
                return deletedVariantValue;
            }
        }

        public List<VariantValue> getAllVariantValue(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantValue.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public VariantValue getVariantValueById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantValue.Find(id);
            }
        }

        public VariantValue updateVariantValue(VariantValue variantValue)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantValue.Update(variantValue);
                prapazdbContext.SaveChanges();
                return variantValue;
            }
        }
    }
}
