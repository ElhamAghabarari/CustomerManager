using CustomerManagement.Application.Interfaces;
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
    }
}
