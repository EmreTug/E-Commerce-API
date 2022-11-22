using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class VariantPictureService
    {
        public VariantPicture createVariantPicture(VariantPicture variantPicture)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantPicture.Add(variantPicture);
                prapazdbContext.SaveChanges();
                return variantPicture;
            }
        }

        public VariantPicture deleteVariantPicture(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedVariantPicture = getVariantPictureById(id);
                prapazdbContext.VariantPicture.Remove(deletedVariantPicture);
                prapazdbContext.SaveChanges();
                return deletedVariantPicture;
            }
        }

        public List<VariantPicture> getAllVariantPicture(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantPicture.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public VariantPicture getVariantPictureById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.VariantPicture.Find(id);
            }
        }

        public VariantPicture updateVariantPicture(VariantPicture variantPicture)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.VariantPicture.Update(variantPicture);
                prapazdbContext.SaveChanges();
                return variantPicture;
            }
        }
    }
}
