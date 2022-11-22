using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IVariantValueService
    {

        List<VariantValue> getAllVariantValue(PaginationParameters paginationParameters);

        VariantValue getVariantValueById(long id);

        VariantValue createVariantValue(VariantValue variantValue);

        VariantValue updateVariantValue(VariantValue variantValue);

        VariantValue deleteVariantValue(long id);
    }
}
