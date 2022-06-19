using BusinessLayer.DTO_s.Order;
using DataAccessLayer.Data.DataBaseModels;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.OrderBL
{
    public interface IOrderBL
    {
        IEnumerable<OrderReadDTO> GetOrders();
        OrderCreatedDTO Post(OrderWriteDTO _order, User _user);

        int PutOrder(Guid id, OrderWriteDTO _order);
        OrderReadDTO GetById(Guid id);

    }
}