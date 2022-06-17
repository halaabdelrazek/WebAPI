using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Order_Repository
{
    public class Order_Repository : Generic_Repository<Order>, IOrder_Repository
    {

        private readonly MyContext _context;

        public Order_Repository(MyContext context) : base(context)
        {
            _context = context;
        }


    }
}
