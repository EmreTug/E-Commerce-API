using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IProductVariantService
    {
        List<ProductVariant> getAllProductVariant(PaginationParameters paginationParameters);

        ProductVariant getProductVariantById(long id);

        ProductVariant createProductVariant(ProductVariant productVariant);

        ProductVariant updateProductVariant(ProductVariant productVariant);

        ProductVariant deleteProductVariant(long id);
    }
}
