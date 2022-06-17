using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.Product
{
    public class ProductReadDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public decimal Salary { get; set; }

    }
}
