using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Abstract
{
    public interface IOrderService
    {
        List<Orders> getAllOrders(PaginationParameters paginationParameters);

        Orders getOrdersById(long id);

        Orders createOrders(Orders orders);

        Orders updateOrders(Orders orders);

        bool deleteOrders(long id);
    }
}
