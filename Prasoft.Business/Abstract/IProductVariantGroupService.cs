using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IProductVariantGroupService
    {

        List<ProductVariantGroup> getAllProductVariantGroup(PaginationParameters paginationParameters);

        ProductVariantGroup getProductVariantGroupById(long id);
        List<ProductVariantGroup> getProductVariantGroupByProductId(long id);

        ProductVariantGroup createProductVariantGroup(ProductVariantGroup productVariantGroup);

        ProductVariantGroup updateProductVariantGroup(ProductVariantGroup productVariantGroup);

        ProductVariantGroup deleteProductVariantGroup(long id);
    }
}
