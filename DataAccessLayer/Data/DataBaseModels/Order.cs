using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.DataBaseModels
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public Guid Id { get; set; }

        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public DateTime OrderCreatedDate { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }




    }
}
