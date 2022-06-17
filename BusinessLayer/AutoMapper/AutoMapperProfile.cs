using AutoMapper;
using BusinessLayer.DTO_s.Order;
using BusinessLayer.DTO_s.Product;
using BusinessLayer.DTO_s.ProductOrder;
using DataAccessLayer.Data.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderReadDTO>();

            CreateMap<Order, OrderCreatedDTO>();

            CreateMap<ProductOrder, ProductOrderReadDTO>();

            CreateMap<OrderWriteDTO, Order>();

            CreateMap<ProductOrderWriteDTO, ProductOrder>();


            CreateMap<Product, ProductReadDTO>();

            CreateMap<ProductWriteDTO, Product>();



        }
    }
}
