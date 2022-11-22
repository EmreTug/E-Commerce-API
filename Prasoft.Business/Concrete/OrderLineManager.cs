using Prasoft.Business.Abstract;
using Prasoft.DataAccess.Abstract;
using Prasoft.DataAccess.Concrete;
using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prasoft.Business.Concrete
{
    public class OrderLineManager : IOrderLineService
    {
        private IOrderLineRepository _OrderLineRepository;
        public OrderLineManager()
        {
            _OrderLineRepository = new OrderLineRepository();
        }
        public OrderLine createOrderLine(OrderLine orderLine)
        {
            return _OrderLineRepository.createOrderLine(orderLine);
        }


        public OrderLine deleteOrderLine(long id)
        {
            return _OrderLineRepository.deleteOrderLine(id);
        }


        public List<OrderLine> getAllOrderLine(PaginationParameters paginationParameters)
        {
            return _OrderLineRepository.getAllOrderLine(paginationParameters);
        }

        public OrderLine getOrderLineById(long id)
        {
            return _OrderLineRepository.getOrderLineById(id);
        }

        public List<OrderLine> getOrderLineByProductId(long id)
        {
            return _OrderLineRepository.getOrderLineByProductId(id);
        }

        public OrderLine updateOrderLine(OrderLine orderLine)
        {
            return _OrderLineRepository.updateOrderLine(orderLine);
        }
    }
}
