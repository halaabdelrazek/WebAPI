using AutoMapper;
using BusinessLayer.DTO_s.Order;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Order_Repository;
using DataAccessLayer.Repositories.Product_Repository;
using DataAccessLayer.Repositories.ProductOrder_Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderBL
{
    public class OrderBL : IOrderBL
    {

        private readonly IOrder_Repository orderRepo;
        private readonly IProductOrder_Repository _productOrderRepo;
        private readonly IProduct_Repository _productRepo;

        private readonly IMapper _mapper;

        public OrderBL(IOrder_Repository orderRepo, IMapper mapper, IProductOrder_Repository productOrderRepo, IProduct_Repository productRepo)
        {
            this.orderRepo = orderRepo;
            _mapper = mapper;
            _productRepo = productRepo;
        }

        public ActionResult<IEnumerable<OrderReadDTO>> GetOrders()
        {
            var ordersFromDB = orderRepo.GetAll();
            return _mapper.Map<List<OrderReadDTO>>(ordersFromDB);

        }

        public OrderCreatedDTO Post(OrderWriteDTO _order, User _user)
        {
            var count = 0;
            var orderToAdd = new Order();

            orderToAdd.Id = Guid.NewGuid();

            orderToAdd.OrderStatus = OrderStatus.PendingReview;

            orderToAdd.OrderCreatedDate = DateTime.Now;

            orderToAdd.User = _user;

            orderToAdd.OrderNumber = "Number"+"_"+ (count++);

            orderRepo.Add(orderToAdd);
            orderRepo.SaveChanges();


            foreach (var item in _order.ProductOrders)
            {
                var product = _productRepo.GetById(item.Id);
                var newOrederProduct = new ProductOrder()
                { OrderId = orderToAdd.Id, Order = orderToAdd, ProductId = product.Id,Product = product, ProductCount = item.ProductCount };

                _productOrderRepo.Add(newOrederProduct);
                _productOrderRepo.SaveChanges();


            }



            return _mapper.Map<OrderCreatedDTO>(orderToAdd);
        }




    }
}
