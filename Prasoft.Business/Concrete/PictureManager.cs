using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Prasoft.Models;

namespace Prasoft.Business.Concrete
{
    public class PictureManager : IPictureService
    {
        private IPictureRepository _PictureRepository;
        public PictureManager()
        {
            _PictureRepository = new PictureRepository();
        }
        public ApiResultModel createPicture(PictureAddViewModel picture)
        {
            return _PictureRepository.createPicture(picture);
        }

        public Picture deletePicture(long id)
        {
           return _PictureRepository.deletePicture(id);
        }

        public List<Picture> getAllPicture(PaginationParameters paginationParameters)
        {
            return _PictureRepository.getAllPicture(paginationParameters);
        }

        public List<Picture> getPictureByProductId(long id)
        {
            return _PictureRepository.getPictureByProductId(id);
        }
        public Picture getPictureById(long id)
        {
            return _PictureRepository.getPictureById(id);
        }

        public Picture updatePicture(Picture picture)
        {
            return _PictureRepository.updatePicture(picture);
        }

      
    }
}
