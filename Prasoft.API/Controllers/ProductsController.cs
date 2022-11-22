using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prasoft.Data;
using Prasoft.DataAccess.Concrete;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prasoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService;
        private ProductVariantGroupService _productVariantGroupService;
        private PictureService _pictureService;
        private ProductVariantService _productVariantService;
        private VariantNameService _variantNameService;
        private VariantPictureService _varyantPictureService;
        private VariantValueService _variantValueService;
        private CategoryService _categoryService;
        private AdminService adminService;
        private OrderLineService OrderLineService;
        public ProductsController()
        {
            _productService = new ProductService();
            _productVariantGroupService = new ProductVariantGroupService();
            _pictureService = new PictureService();
            _productVariantService = new ProductVariantService();
            _variantNameService = new VariantNameService();
            _varyantPictureService = new VariantPictureService();
            _variantValueService = new VariantValueService();
            adminService = new AdminService();
            OrderLineService = new OrderLineService();
            _categoryService = new CategoryService();
        }



        /// <summary>
        /// Get All Product
        /// </summary>
        /// <returns></returns>
        /// *******************
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllProduct([FromQuery] PaginationParameters paginationParameters)
        {
            var products = _productService.getAllProduct(paginationParameters);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }


        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        /// *******************
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCategory()
        {

            var category = _categoryService.getAllCategories();
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }




        ///// <summary>
        ///// Get All Picture
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllPicture([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var pictures = _pictureService.getAllPicture(paginationParameters);
        //    if (pictures != null)
        //    {
        //        return Ok(pictures);
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        [Route("[action]")]
        public IActionResult getAdminByUsername(string username, string password)
        {
            bool admin = adminService.getAdminByUserName(username, password);
            if (admin == true)
            {
                return Ok(admin);
            }
            return NotFound();
        }


        ///// <summary>
        ///// Get All Product Variant Group
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllProductVariantGroup([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var productVariantGroups = _productVariantGroupService.getAllProductVariantGroup(paginationParameters);
        //    if (productVariantGroups != null)
        //    {
        //        return Ok(productVariantGroups);
        //    }
        //    return NotFound();
        //}
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllOrderLine([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var orderline = OrderLineService.getAllOrderLine(paginationParameters);
        //    if (orderline != null)
        //    {
        //        return Ok(orderline);
        //    }
        //    return NotFound();
        //}




        ///// <summary>
        ///// Get All Product Variant
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllProductVariant([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var productVariants = _productVariantService.getAllProductVariant(paginationParameters);
        //    if (productVariants != null)
        //    {
        //        return Ok(productVariants);
        //    }
        //    return NotFound();
        //}



        ///// <summary>
        ///// Get All Variant Name
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllVariantName([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var variantNames = _variantNameService.getAllVariantName(paginationParameters);
        //    if (variantNames != null)
        //    {
        //        return Ok(variantNames);
        //    }
        //    return NotFound();
        //}



        ///// <summary>
        ///// Get All Variant Value
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllVariantValue([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var variantValues = _variantValueService.getAllVariantValue(paginationParameters);
        //    if (variantValues != null)
        //    {
        //        return Ok(variantValues);
        //    }
        //    return NotFound();
        //}



        ///// <summary>
        ///// Get All Variant Picture
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllVariantPicture([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var variantPictures = _varyantPictureService.getAllVariantPicture(paginationParameters);
        //    if (variantPictures != null)
        //    {
        //        return Ok(variantPictures);
        //    }
        //    return NotFound();
        //}



        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult getProductByBarcode(string barcode)
        {
            var product = _productService.getProductByBarcode(barcode);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult getPictureByProductID(long id)
        //{
        //    var picture = _pictureService.getPictureByProductId(id);
        //    if (picture != null)
        //    {
        //        return Ok(picture);
        //    }
        //    return NotFound();
        //}


        //[HttpGet]
        //[Route("[action]/{name}")]
        //public IActionResult getProductByName(string name)
        //{
        //    var product = _productService.getProductByName(name);
        //    if (product != null)
        //    {
        //        return Ok(product);
        //    }
        //    return NotFound();
        //}



        ///// <summary>
        ///// Update the Product
        ///// </summary>
        ///// <param name="u"></param>
        ///// <returns></returns>
        /////*********************
        //[HttpPut]
        //[Route("[action]")]
        //public IActionResult PutProduct([FromBody] Product u)
        //{
        //    var product = _productService.updateProduct(u);
        //    if (product != null)
        //    {
        //        return Ok(product);
        //    }
        //    return NotFound();
        //}



        /// <summary>
        /// Delete the Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteProduct(long id)

        {
            var result = _productService.deleteProduct(id);
            if (result)
            {
                return Ok("Delected");
            }
            return NotFound();
        }




        /// <summary>
        /// Create the Product
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        /// ********************
        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult PostProduct([FromBody] Product u)
        //{
        //    return Ok(_productService.createProduct(u));
        //}
        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult PostPicture([FromBody] PictureAddViewModel p)
        //{
        //    return Ok(_pictureService.createPicture(p));
        //}
        [HttpPost]
        [Route("[action]")]
        public IActionResult add([FromBody] ProductAddModel u)
        {
            return Ok(_productService.add(u));
        }



    }
}
