using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IPictureService
    {
        List<Picture> getAllPicture(PaginationParameters paginationParameters);

        List<Picture> getPictureByProductId(long id);

        Picture getPictureById(long id);

        ApiResultModel createPicture(PictureAddViewModel r);

        Picture updatePicture(Picture r);

        Picture deletePicture(long id);
    }
}
