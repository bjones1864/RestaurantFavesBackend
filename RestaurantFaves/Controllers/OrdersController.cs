using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantFaves.Models;

namespace RestaurantFaves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrdersDbContext dbContext = new OrdersDbContext();

        [HttpGet()]
        public IActionResult GetAll(string? restaurant = null, bool? orderAgain = null)
        {
            List<Order> result = dbContext.Orders.ToList();

            if(restaurant != null)
            {
                result = result.Where(o => o.Restaurant.ToLower().Contains(restaurant.ToLower())).ToList();
            }
            if(orderAgain != null)
            {
                result = result.Where(o => o.OrderAgain == orderAgain).ToList();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Order result = dbContext.Orders.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost()]
        public IActionResult AddOrder([FromBody] Order newOrder)
        {
            newOrder.Id = 0;
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
            return Created($"/Orders/Api/{newOrder.Id}", newOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            Order result = dbContext.Orders.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Orders.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if(updatedOrder.Id != id)
            {
                return BadRequest();
            }
            else if(!dbContext.Orders.Any(o => o.Id == id))
            {
                return NotFound();
            }
            else
            {
                dbContext.Orders.Update(updatedOrder);
                dbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}