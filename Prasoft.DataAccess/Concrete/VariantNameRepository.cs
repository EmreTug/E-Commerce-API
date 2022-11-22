using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class VariantNameService
    {
        public VariantName createVariantName(VariantName variantName)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantName.Add(variantName);
                prapazdbContext.SaveChanges();
                return variantName;
            }
        }

        public VariantName deleteVariantName(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedVariantName = getVariantNameById(id);
                foreach (var variantValue1
                in deletedVariantName.VariantValue)
                {
                    prapazdbContext.VariantValue.Remove(variantValue1);
                }
                foreach (var productVariant
             in deletedVariantName.ProductVariant)
                {
                    prapazdbContext.ProductVariant.Remove(productVariant);
                }
                prapazdbContext.VariantName.Remove(deletedVariantName);
                prapazdbContext.SaveChanges();
                return deletedVariantName;
            }
        }

        public List<VariantName> getAllVariantName(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantName.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public VariantName getVariantNameById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantName.Find(id);
            }
        }

        public VariantName updateVariantName(VariantName variantName)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantName.Update(variantName);
                prapazdbContext.SaveChanges();
                return variantName;
            }
        }
    }
}
