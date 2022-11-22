using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IOrderLineService
    {
        List<OrderLine> getAllOrderLine(PaginationParameters paginationParameters);

        OrderLine getOrderLineById(long id);
        List<OrderLine> getOrderLineByProductId(long id);

        OrderLine createOrderLine(OrderLine orderLine);

        OrderLine updateOrderLine(OrderLine orderLine);

        OrderLine deleteOrderLine(long id);
    }
}
