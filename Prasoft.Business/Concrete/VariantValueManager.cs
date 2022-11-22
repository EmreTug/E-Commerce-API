using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class VariantValueManager : IVariantValueService
    {
        private IVariantValueRepository _VariantValueRepository;
        public VariantValueManager()
        {
            _VariantValueRepository = new VariantValueRepository();
        }
        public VariantValue createVariantValue(VariantValue varyantDeger)
        {
            return _VariantValueRepository.createVariantValue(varyantDeger);
        }

        public VariantValue deleteVariantValue(long id)
        {
            return _VariantValueRepository.deleteVariantValue(id);
        }

        public List<VariantValue> getAllVariantValue(PaginationParameters paginationParameters)
        {
            return _VariantValueRepository.getAllVariantValue(paginationParameters);
        }

        public VariantValue getVariantValueById(long id)
        {
            return _VariantValueRepository.getVariantValueById(id);
        }

        public VariantValue updateVariantValue(VariantValue variantValue)
        {
            return _VariantValueRepository.updateVariantValue(variantValue);
        }
    }
}
