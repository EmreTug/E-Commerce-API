using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class VariantPictureManager : IVaryantPictureService
    {
        private IVariantPictureRepository _VariantPictureRepository;
        public VariantPictureManager()
        {
            _VariantPictureRepository = new VariantPictureRepository();
        }
        public VariantPicture createVariantPicture(VariantPicture variantPicture)
        {
            return _VariantPictureRepository.createVariantPicture(variantPicture);
        }

        public VariantPicture deleteVariantPicture(long id)
        {
            return _VariantPictureRepository.deleteVariantPicture(id);
        }

        public List<VariantPicture> getAllVariantPicture(PaginationParameters paginationParameters)
        {
            return _VariantPictureRepository.getAllVariantPicture(paginationParameters);
        }

        public VariantPicture getVariantPictureById(long id)
        {
            return _VariantPictureRepository.getVariantPictureById(id);
        }

        public VariantPicture updateVariantPicture(VariantPicture variantPicture)
        {
            return _VariantPictureRepository.updateVariantPicture(variantPicture);
        }
    }
}
