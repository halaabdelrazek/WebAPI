using BusinessLayer.DTO_s.ProductOrder;
using DataAccessLayer.Data.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.Order
{
    public class OrderReadDTO
    {
        public Guid Id { get; set; }

        public string OrderNumber { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime OrderCreatedDate { get; set; }

        public ICollection<ProductOrderReadDTO> ProductOrders { get; init; }


    }
}
