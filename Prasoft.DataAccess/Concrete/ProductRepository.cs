using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Prasoft.Models;

namespace Prasoft.DataAccess.Concrete
{
    public class ProductService
    {


        public Product createProduct(Product product)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.Product.Add(product);
                prapazdbContext.SaveChanges();
                return product;
            }
        }

        public bool deleteProduct(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedUrun = prapazdbContext.Product.FirstOrDefault(a => a.Id == id);
                var orderExist = prapazdbContext.OrderLine.Any(x => x.ProductId == id);
                if (!orderExist && deletedUrun != null)
                {
                 
                    var pro = deletedUrun.ProductVariantGroup.ToList();
                    foreach (var variantGroup in pro)
                    {
                        var variants = variantGroup.ProductVariant.ToList();
                        foreach (var variant in variants)
                        {
                            variantGroup.ProductVariant.Remove(variant);
                            prapazdbContext.ProductVariant.Remove(variant);
                        }
                   
                        var pictures = variantGroup.VariantPicture.ToList();
                        foreach (var picture in pictures)
                        {
                            variantGroup.VariantPicture.Remove(picture);
                            prapazdbContext.VariantPicture.Remove(picture);
                        }
                        deletedUrun.ProductVariantGroup.Remove(variantGroup);
                        prapazdbContext.ProductVariantGroup.Remove(variantGroup);
                    }
                    var images = deletedUrun.Picture.ToList();
                    foreach (var image in images)
                    {
                        deletedUrun.Picture.Remove(image);
                        prapazdbContext.Picture.Remove(image);
                    }

                    prapazdbContext.Product.Remove(deletedUrun);
                    prapazdbContext.SaveChanges();
                    return true;
                }
                return false;
            }


        }

        public List<ProductListModel> getAllProduct(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var x = prapazdbContext.Product.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .Select(a => new ProductListModel
                                            {
                                                Id=a.Id,
                                                Price=a.Price,
                                                Stock=a.Stock,
                                                CategoryName=a.Category.Name,
                                                Barcode = a.Barcode,
                                                Name = a.Name,
                                                Images = a.Picture.Select(x => x.Picture1).ToList(),
                                                Description=a.Description,
                                                Variants=(from v in a.ProductVariantGroup select new ProductVariantGroupModel
                                                {Barcode=v.Barcode,
                                                ProductId=v.ProductId,
                                                Id=v.Id,
                                                Stock=v.Stock,
                                                Price=v.Price,
                                                Images=v.VariantPicture.Select(y=>y.Picture.Picture1).ToList(),
                                                
                                                    VariantNames = (from n in v.ProductVariant select new VariantNameModel
                                                    {
                                                        VariantName=n.VariantName.VariantName1,
                                                        VariantValue=n.VariantValue.Value
                                                    }).ToList()
                                                }).ToList()
                                            })
                                            .ToList();
           
                return x;
            }
        }

        public ProductListModel getProductByBarcode(string barcode)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {

                var x = prapazdbContext.Product.Where(on => on.Barcode == barcode)
                                            .Select(a => new ProductListModel
                                            {
                                                Price = a.Price,
                                                Stock = a.Stock,
                                                Barcode = a.Barcode,
                                                Name = a.Name,
                                                Images = a.Picture.Select(x => x.Picture1).ToList(),
                                                Description = a.Description,
                                                Variants = (from v in a.ProductVariantGroup
                                                            select new ProductVariantGroupModel
                                                            {
                                                                Barcode = v.Barcode,
                                                                Stock = v.Stock,
                                                                Price = v.Price,
                                                                Images = v.VariantPicture.Select(y => y.Picture.Picture1).ToList(),

                                                                //Images = from p in v.VariantPicture select new Picture {=p.Picture.Picture1 },
                                                                VariantNames = (from n in v.ProductVariant
                                                                                select new VariantNameModel
                                                                                {
                                                                                    VariantName = n.VariantName.VariantName1,
                                                                                    VariantValue = n.VariantValue.Value
                                                                                }).ToList()
                                                            }).ToList()
                                            })
                                            .ToList();
                var y = x.FirstOrDefault();
                return y;
            }
        }

        public Product getProductByName(string name)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.Product.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public Product updateProduct(Product product)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.Product.Update(product);

                prapazdbContext.SaveChanges();
                return product;
            }
        }

        public ApiResultModel add(ProductAddModel productAdd)
        {
            var resultModel = new ApiResultModel
            {
                Success = false
            };
            using (var prapazdbContext = new PrapazdbContext())
            {
                var product = new Product
                {
                    Name = productAdd.Name,
                    Description = productAdd.Description,
                    Barcode = productAdd.Barcode,
                    Stock = productAdd.Stock,
                    Price = productAdd.Price,

                };
                //  var images = productAdd.Variants.SelectMany(a => a.Images).Distinct().ToList();
                foreach (var image in productAdd.Images)
                {
                    product.Picture.Add(new Picture { Picture1 = image });
                }


                foreach (var variant in productAdd.Variants)
                {
                    var variantGroup = new ProductVariantGroup
                    {
                        Barcode = variant.Barcode,
                        Price = variant.Price,
                        Stock = variant.Stock,
                        



                    };


                    foreach (var variantName in variant.VariantNames)
                    {
                        var variantNameDb = product.ProductVariantGroup.SelectMany(a=>a.ProductVariant).FirstOrDefault(vn=>vn.VariantName.VariantName1==variantName.VariantName)?.VariantName;
                        if (variantNameDb == null)
                        {
                            variantNameDb = prapazdbContext.VariantName.FirstOrDefault(a => a.VariantName1 == variantName.VariantName);
                        } 
                        if (variantNameDb == null)
                        {
                            variantNameDb = new VariantName
                            {
                                VariantName1 = variantName.VariantName
                            };
                        }


                        var variantValueDb = product.ProductVariantGroup.SelectMany(a => a.ProductVariant).FirstOrDefault(vn => vn.VariantValue.Value == variantName.VariantValue)?.VariantValue;
                        if (variantValueDb == null)
                        {
                            variantValueDb= prapazdbContext.VariantValue.FirstOrDefault(vn => vn.Value == variantName.VariantValue);
                       
                        }
                        if (variantValueDb==null)
                        {
                            variantValueDb = new VariantValue
                            {
                                Value = variantName.VariantValue,
                                VariantName = variantNameDb

                            };
                        }
                        variantGroup.ProductVariant.Add(new ProductVariant { VariantName = variantNameDb, VariantValue = variantValueDb });

                    }
                    foreach (var img in variant.Images)
                    {
                        var localImage = product.Picture.FirstOrDefault(a => a.Picture1 == img);
                        if (localImage == null)
                        {
                            localImage = new Picture { Picture1 = img };
                            product.Picture.Add(localImage);
                            variantGroup.VariantPicture.Add(new VariantPicture { Picture = localImage });
                        }
                        else
                        {
                            variantGroup.VariantPicture.Add(new VariantPicture { Picture = localImage });

                        }
                    }
                    product.ProductVariantGroup.Add(variantGroup);
                }

                prapazdbContext.Product.Add(product);
                prapazdbContext.SaveChanges();
                resultModel.Success = true;
                resultModel.item = new { Id = product.Id };
                return resultModel;
            }
        }



    }
}
