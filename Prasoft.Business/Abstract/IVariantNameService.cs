using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IVariantNameService
    {
        List<VariantName> getAllVariantName(PaginationParameters paginationParameters);

        VariantName getVariantNameById(long id);

        VariantName createVariantName(VariantName variantName);

        VariantName updateVariantName(VariantName variantName);

        VariantName deleteVariantName(long id);
    }
}
