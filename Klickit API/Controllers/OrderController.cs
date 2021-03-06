using BusinessLayer.DTO_s.Order;
using BusinessLayer.OrderBL;
using DataAccessLayer.Data.DataBaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace Klickit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrderController : ControllerBase
    {

        private readonly IOrderBL _orderBL;

        private readonly UserManager<User> _userManager;

        public OrderController(UserManager<User> userManager, IOrderBL orderBL)
        {

            _userManager = userManager;
            _orderBL = orderBL;


        }

   
        [HttpPost]
        public async Task<ActionResult<OrderCreatedDTO>> PostOrder(OrderWriteDTO order)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = await _userManager.FindByEmailAsync(email);
          

            var orderRead = _orderBL.Post(order, user);
            
            return Created("order Created", orderRead);
        }


        [HttpGet]
        public async Task<ActionResult<OrderReadDTO>> GetAllOrder()
        {
           
            var orderRead = _orderBL.GetOrders();

            return Ok(orderRead);
        }


        // PUT: api/Order/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public ActionResult<OrderReadDTO> PutOrder(Guid id, OrderWriteDTO order)
        {
           
            if (_orderBL.PutOrder(id, order) == 0)
            {
                return NotFound();
            }

            var returnedOrder = _orderBL.GetById(id);



            return Ok(returnedOrder);
        }


    }
}
