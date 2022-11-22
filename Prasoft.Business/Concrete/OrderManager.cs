using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderRepository _ordersRepository;
        public OrderManager()
        {
            _ordersRepository = new OrderRepository();
        }
        public Orders createOrders(Orders orders)
        {
            return _ordersRepository.createOrders(orders);
        }

        public bool deleteOrders(long id)
        {
            return _ordersRepository.deleteOrders(id);
        }

        public List<Orders> getAllOrders(PaginationParameters paginationParameters)
        {
            return _ordersRepository.getAllOrders(paginationParameters);
        }

        public Orders getOrdersById(long id)
        {
            return _ordersRepository.getOrdersById(id);
        }

        public Orders updateOrders(Orders orders)
        {
            return _ordersRepository.updateOrders(orders);
        }
    }
}
