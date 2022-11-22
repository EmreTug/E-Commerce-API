using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class ProductVariantManager : IProductVariantService
    {
        private IProductVariantRepository _ProductVariantRepository;
        public ProductVariantManager()
        {
            _ProductVariantRepository = new ProductVariantRepository();
        }
        public ProductVariant createProductVariant(ProductVariant productVariant)
        {
            return _ProductVariantRepository.createProductVariant(productVariant);
        }

        public ProductVariant deleteProductVariant(long id)
        {
            return _ProductVariantRepository.deleteProductVariant(id);
        }

        public List<ProductVariant> getAllProductVariant(PaginationParameters paginationParameters)
        {
            return _ProductVariantRepository.getAllProductVariant(paginationParameters);
        }

        public ProductVariant getProductVariantById(long id)
        {
            return _ProductVariantRepository.getProductVariantById(id);
        }

        public ProductVariant updateProductVariant(ProductVariant productVariant)
        {
            return _ProductVariantRepository.updateProductVariant(productVariant);
        }
    }
}
