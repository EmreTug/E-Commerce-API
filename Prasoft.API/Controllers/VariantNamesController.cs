using Bogus;
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
    public class VariantNamesController : ControllerBase
    {
        private VariantNameService _variantNameService;
        public VariantNamesController()
        {
            _variantNameService = new VariantNameService();

        }

        ///// <summary>
        ///// Get All Variant Name
        ///// </summary>
        ///// <param name="paginationParameters"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetAllVariantName([FromQuery] PaginationParameters paginationParameters)
        //{
        //    var variantName = _variantNameService.getAllVariantName(paginationParameters);
        //    return Ok(variantName);
        //}
        ///// <summary>
        ///// Create Variant Name
        ///// </summary>
        ///// <param name="u"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult PostVariantName([FromBody] VariantName u)
        //{
        //    return Ok(_variantNameService.createVariantName(u));
        //}
        //private static VariantName _variantNames;
        //[HttpDelete]
        //[Route("[action]")]
        //public IActionResult Add()
        //{
        //    var prapazdbContext = new PrapazdbContext();
        //    for(int i = 0; i < 2000; i++)
        //    {
        //        _variantNames = new Faker<VariantName>()
        //             .RuleFor(u => u.VariantName1, f => f.Name.FindName());
        //        prapazdbContext.VariantNames.Add(_variantNames);
        //    }
            
        //    prapazdbContext.SaveChanges();
        //    return Ok(_variantNames);
        //}

    }
}
