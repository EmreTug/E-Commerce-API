using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IVaryantPictureService
    {
        List<VariantPicture> getAllVariantPicture(PaginationParameters paginationParameters);

        VariantPicture getVariantPictureById(long id);

        VariantPicture createVariantPicture(VariantPicture variantPicture);

        VariantPicture updateVariantPicture(VariantPicture variantPicture);

        VariantPicture deleteVariantPicture(long id);
    }
}
