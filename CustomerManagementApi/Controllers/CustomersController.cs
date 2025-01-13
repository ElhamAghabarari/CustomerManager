
using CustomerManagement.Application.Models;
using CustomerManagement.Application.Services.commands;
using CustomerManagement.Application.Services.notifications;
using CustomerManagement.Application.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;
        public CustomersController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]string search="")
        {
            var list = await _sender.Send(new CustomerGetAllQuery(search));
           // System.Threading.Thread.Sleep(5000);
            return  Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _sender.Send(new CustomerGetByIdQuery(id));
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Customer customer)
        {
            await _sender.Send(new CustomerAddCommand(customer));
            await _publisher.Publish(new CustomerAddNotification(customer));
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            await _sender.Send(new CustomerUpdateCommand(customer));
            return Ok(customer);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sender.Send(new CustomerDeleteCommand(id));
            return Ok();
        }
    }
}
