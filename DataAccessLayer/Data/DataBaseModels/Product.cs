using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.DataBaseModels
{
    public class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public int StockNum { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }

    }
}
