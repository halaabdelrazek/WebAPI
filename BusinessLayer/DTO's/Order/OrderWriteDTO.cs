using BusinessLayer.DTO_s.ProductOrder;
using DataAccessLayer.Data.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.Order
{
    public class OrderWriteDTO
    {
        public OrderStatus? OrderStatus { get; set; }

        public ICollection<ProductOrderWriteDTO>? ProductOrders { get; init; }

    }
}
