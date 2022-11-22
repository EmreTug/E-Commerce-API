using Prasoft.Data;
using Prasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prasoft.DataAccess.Concrete
{
    public class OrderLineService
    {
        public OrderLine createOrderLine(OrderLine orderLine)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.OrderLine.Add(orderLine);
                prapazdbContext.SaveChanges();
                return orderLine;
            }
        }

        public OrderLine deleteOrderLine(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedOrderLine = getOrderLineById(id);
                prapazdbContext.OrderLine.Remove(deletedOrderLine);
                prapazdbContext.SaveChanges();
                return deletedOrderLine;
            }
        }

        public List<OrderLine> getAllOrderLine(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.OrderLine.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .ToList();
            }
        }

        public OrderLine getOrderLineById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.OrderLine.Find(id);
            }
        }

        public List<OrderLine> getOrderLineByProductId(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.OrderLine.Where(x => x.ProductId == id).ToList();

            }
        }

        public OrderLine updateOrderLine(OrderLine orderLine)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.OrderLine.Update(orderLine);
                prapazdbContext.SaveChanges();
                return orderLine;
            }
        }
    }
}
