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
        private static int  count = 0;


        private readonly IMapper _mapper;

        public OrderBL(IOrder_Repository orderRepo, IMapper mapper, IProductOrder_Repository productOrderRepo, IProduct_Repository productRepo)
        {
            this.orderRepo = orderRepo;
            _mapper = mapper;
            _productRepo = productRepo;
            _productOrderRepo = productOrderRepo;
        }

        public IEnumerable<OrderReadDTO> GetOrders()
        {
            var ordersFromDB = orderRepo.GetAll();
            return _mapper.Map<List<OrderReadDTO>>(ordersFromDB);

        }

        public OrderCreatedDTO Post(OrderWriteDTO _order, User _user)
        {
            count++;

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
                var newOrederProduct = new ProductOrder()
                { OrderId = orderToAdd.Id, ProductId = item.Id, ProductCount = item.ProductCount };

                _productOrderRepo.Add(newOrederProduct);
                _productOrderRepo.SaveChanges();


            }



            return _mapper.Map<OrderCreatedDTO>(orderToAdd);
        }


        public int PutOrder(Guid id, OrderWriteDTO _order)
        {
        
            var orderToEdit = orderRepo.GetById(id);
            if (orderToEdit is null)
            {
                // retun 0 to order not found

                return 0;
            }


            _mapper.Map(_order, orderToEdit);


            orderRepo.Update(orderToEdit);
            orderRepo.SaveChanges();

            // retun 1 to update order done

            return 1;
        }


        public OrderReadDTO GetById(Guid id)
        {
            var orderFromDB = orderRepo.GetById(id);

            return _mapper.Map<OrderReadDTO>(orderFromDB);
        }


    }
}
