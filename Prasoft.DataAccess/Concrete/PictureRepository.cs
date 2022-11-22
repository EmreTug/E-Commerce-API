using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prasoft.Models;
//hamiyet
namespace Prasoft.DataAccess.Concrete
{
    public class PictureService
    {
        public ApiResultModel createPicture(PictureAddViewModel pictureAdd)
        {
            var resultModel = new ApiResultModel
            {
                Success = false
            };
            using (var prapazdbContext = new PrapazdbContext())
            {
                var product = prapazdbContext.Product.FirstOrDefault(a => a.Id == pictureAdd.ProductId);
                if (product == null)
                {
                    resultModel.ErrorMessages.Add("ürün bulunamadı");
                    return resultModel;
                }
                var picture = new Picture
                {
                    ProductId = pictureAdd.ProductId,
                    Picture1 = pictureAdd.ImageUrl

                };
                prapazdbContext.Picture.Add(picture);
                prapazdbContext.SaveChanges();
                resultModel.Success = true;
                resultModel.item = new { Id=picture.Id};
                return resultModel;
            }
        }
  

        public Picture deletePicture(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedPicture = getPictureById(id);
                prapazdbContext.Picture.Remove(deletedPicture);
                prapazdbContext.SaveChanges();
                return deletedPicture;
            }
        }

        public List<Picture> getAllPicture(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.Picture.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public Picture getPictureById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.Picture.Find(id);
            }
        }

        public List<Picture> getPictureByProductId(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.Picture.Where(x => x.ProductId == id).ToList();
            }
        }

        public Picture updatePicture(Picture picture)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.Picture.Update(picture);
                prapazdbContext.SaveChanges();
                return picture;
            }
        }
    }
  
}

