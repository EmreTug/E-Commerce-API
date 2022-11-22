using Prasoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Prasoft.Models;

namespace Prasoft.DataAccess.Concrete
{
    public class OrderService
    {

        public ApiResultModel add(OrderAddModel order)
        {
            var resultModel = new ApiResultModel
            {
                Success = false
            };
            using (var prapazdbContext = new PrapazdbContext())
            {
                var newOrder = new Orders
                {
                    CustomerName = order.CustomerName,
                    CustomerAddress = order.CustomerAddress,
                    CustomerMailAddress = order.CustomerMailAddress,
                    CustomerPhoneNumber = order.CustomerPhoneNumber,
                    CustomerTaxAdministration = order.CustomerTaxAdministration,
                    CustomerTaxId = order.CustomerTaxId,
                    OrderDate = order.OrderDate,


                };
                //  var images = productAdd.Variants.SelectMany(a => a.Images).Distinct().ToList();



                foreach (var orderLine in order.OrderLine)
                {
                    var OrderLine = new OrderLine
                    {
                        DiscountRate = orderLine.DiscountRate,
                        Quantity = orderLine.Quantity,
                        UnitPrice = orderLine.UnitPrice,
                        ProductId = orderLine.ProductId,
                        ProductVariantGroupId = orderLine.ProductVariantGroupId,



                    };


                    newOrder.OrderLine.Add(OrderLine);
                }

                prapazdbContext.Orders.Add(newOrder);
                prapazdbContext.SaveChanges();
                resultModel.Success = true;
                resultModel.item = new { Id = newOrder.Id };
                return resultModel;
            }
        }


        public bool deleteOrders(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var deletedOrders = prapazdbContext.Orders.Include(a => a.OrderLine).FirstOrDefault(x => x.Id == id);

                if (deletedOrders != null)
                {
                    var orderLines = deletedOrders.OrderLine.ToList();
                    foreach (var order in orderLines)
                    {

                        prapazdbContext.OrderLine.Remove(order);
                    }
                    prapazdbContext.Orders.Remove(deletedOrders);
                    prapazdbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<OrderListModel> getAllOrders(PaginationParameters paginationParameters)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                var x = prapazdbContext.Orders.OrderBy(on => on.Id)
                                            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                                            .Take(paginationParameters.PageSize)
                                            .Select(a => new OrderListModel
                                            {
                                                CustomerAddress = a.CustomerAddress,
                                                CustomerMailAddress = a.CustomerMailAddress,
                                                CustomerName = a.CustomerName,
                                                CustomerPhoneNumber = a.CustomerPhoneNumber,
                                                CustomerTaxAdministration = a.CustomerTaxAdministration,
                                                CustomerTaxId = a.CustomerTaxId,
                                                OrderDate = a.OrderDate,

                                                OrderLine = (from v in a.OrderLine
                                                             select new OrderLineListModel
                                                             {
                                                                 DiscountRate = v.DiscountRate,
                                                                 ProductName = v.Product.Name,
                                                                 Quantity = v.Quantity,
                                                                 UnitPrice = v.UnitPrice,
                                                                 Variant = new ProductVariantGroupModel
                                                                 {
                                                                     Barcode = v.ProductVariantGroup.Barcode,
                                                                     Price = v.ProductVariantGroup.Price,
                                                                     Stock = v.ProductVariantGroup.Stock,
                                                                     VariantNames=(from z in v.ProductVariantGroup.ProductVariant select new VariantNameModel {VariantName=z.VariantName.VariantName1,VariantValue=z.VariantValue.Value }).ToList()
                                                                 },


                                                             }).ToList()
                                            })
                                            .ToList();

                return x;
            }
        }


        public Orders getOrdersById(long id)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                return prapazdbContext.Orders.Find(id);
            }
        }

        public Orders updateOrders(Orders orders)
        {
            using (var prapazdbContext = new PrapazdbContext())
            {
                prapazdbContext.Orders.Update(orders);
                prapazdbContext.SaveChanges();
                return orders;
            }
        }
    }
}
