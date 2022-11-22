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
    public class OrdersController : ControllerBase
    {
        private OrderService _orderService;
        private OrderLineService _orderLineService;
        public OrdersController()
        {
            _orderService = new OrderService();
            _orderLineService = new OrderLineService();
        }



       
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrder([FromQuery] PaginationParameters paginationParameters)
        {
            var orders = _orderService.getAllOrders(paginationParameters);
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrderLine([FromQuery] PaginationParameters paginationParameters)
        {
            var orders = _orderLineService.getAllOrderLine(paginationParameters);
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }



        ///// <summary>
        ///// Get Order By Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        ///// *******************
        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult GetOrderById(long id)
        //{
        //    var orders = _orderService.getOrdersById(id);
        //    if (orders != null)
        //    {
        //        return Ok(orders);
        //    }
        //    return NotFound();
        //}




        /// <summary>
        /// Update the Order
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// ********************
        //[HttpPut]
        //[Route("[action]/{id}")]
        //public IActionResult PutOrder([FromBody] Orders s)
        //{
        //    var orders = _orderService.updateOrders(s);
        //    if (orders != null)
        //    {
        //        return Ok(orders);
        //    }
        //    return NotFound();
        //}




        ///// <summary>
        ///// Delete the Order
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        ///// *******************
        //[HttpDelete]
        //[Route("[action]")]
        //public IActionResult DeleteOrder(long id)
        //{
        //    var result = _orderService.deleteOrders(id);
        //    if (result)
        //    {
        //        return Ok("Delected");
        //    }
        //    return NotFound();
        //}






        [HttpPost]
        [Route("[action]")]
        public IActionResult PostOrder([FromBody] OrderAddModel s)
        {
            return Ok(_orderService.add(s));
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult PostOrderLine([FromBody] OrderLine orderLine)
        {
            return Ok(_orderLineService.createOrderLine(orderLine));
        }
    }
}
