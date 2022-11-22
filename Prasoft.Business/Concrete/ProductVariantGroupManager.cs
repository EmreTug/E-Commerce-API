using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class ProductVariantGroupManager : IProductVariantGroupService
    {
        private IProductVariantGroupRepository _ProductVariantGroupRepository;
        public ProductVariantGroupManager()
        {
            _ProductVariantGroupRepository = new ProductVariantGroupRepository();
        }
        public ProductVariantGroup createProductVariantGroup(ProductVariantGroup productVariantGroup)
        {
            return _ProductVariantGroupRepository.createProductVariantGroup(productVariantGroup);
        }

        public ProductVariantGroup deleteProductVariantGroup(long id)
        {
            return _ProductVariantGroupRepository.deleteProductVariantGroup(id);
        }

        public List<ProductVariantGroup> getAllProductVariantGroup(PaginationParameters paginationParameters)
        {
            return _ProductVariantGroupRepository.getAllProductVariantGroup(paginationParameters);
        }

        public ProductVariantGroup getProductVariantGroupById(long id)
        {
            return _ProductVariantGroupRepository.getProductVariantGroupById(id);
        }

        public List<ProductVariantGroup> getProductVariantGroupByProductId(long id)
        {
            return _ProductVariantGroupRepository.getProductVariantGroupByProductId(id);
        }

        public ProductVariantGroup updateProductVariantGroup(ProductVariantGroup productVariantGroup)
        {
            return _ProductVariantGroupRepository.updateProductVariantGroup(productVariantGroup);
        }
    }
}
