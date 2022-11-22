using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class VariantNameManager : IVariantNameService
    {
        private IVariantNameRepository _VariantNameRepository;
        public VariantNameManager()
        {
            _VariantNameRepository = new VariantNameRepository();
        }

        public VariantName createVariantName(VariantName varyantIsim)
        {
            return _VariantNameRepository.createVariantName(varyantIsim);
        }

        public VariantName deleteVariantName(long id)
        {
            return _VariantNameRepository.deleteVariantName(id);
        }

        public List<VariantName> getAllVariantName(PaginationParameters paginationParameters)
        {
            return _VariantNameRepository.getAllVariantName(paginationParameters);
        }

        public VariantName getVariantNameById(long id)
        {
            return _VariantNameRepository.getVariantNameById(id);
        }

        public VariantName updateVariantName(VariantName variantName)
        {
            return _VariantNameRepository.updateVariantName(variantName);
        }
    }
}
