using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerServive) {
            _customerService = customerServive;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_customerService.GetCustomer(id));
        }

        [HttpPut]
        public ActionResult Add(Customer customer)
        {
            return Ok(_customerService.InsertCustomer(customer));
        }

        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
