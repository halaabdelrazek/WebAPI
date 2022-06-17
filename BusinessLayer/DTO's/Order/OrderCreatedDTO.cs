using DataAccessLayer.Data.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.Order
{
    public class OrderCreatedDTO
    {
        public Guid Id { get; set; }

        public string OrderNumber { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime OrderCreatedDate { get; set; }
    }
}
