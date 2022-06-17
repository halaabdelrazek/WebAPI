using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.ProductOrder_Repository
{
    public class ProductOrder_Repository : Generic_Repository<ProductOrder>, IProductOrder_Repository
    {
        private readonly MyContext _context;

        public ProductOrder_Repository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
