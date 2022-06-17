using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Product_Repository
{
    public class Product_Repository : Generic_Repository<Product>, IProduct_Repository
    {
        private readonly MyContext _context;

        public Product_Repository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
