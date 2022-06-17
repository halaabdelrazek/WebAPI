using BusinessLayer.DTO_s.Order;
using DataAccessLayer.Data.DataBaseModels;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.OrderBL
{
    public interface IOrderBL
    {
        ActionResult<IEnumerable<OrderReadDTO>> GetOrders();
        OrderCreatedDTO Post(OrderWriteDTO _order, User _user);
    }
}