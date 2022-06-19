using BusinessLayer.DTO_s.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.ProductOrder
{
    public record ProductOrderReadDTO
    {
        public ProductReadDTO? Product { get; init; }

        public int ProductCount { get; init; }
    }
}
