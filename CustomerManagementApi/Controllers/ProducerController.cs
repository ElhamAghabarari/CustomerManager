using CustomerManagement.WebApi.producer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/producer")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerService _producerService;

        public ProducerController(ProducerService producer)
        {
            _producerService= producer;
        }

        [HttpPost]
        public async Task<IActionResult> sendMassage([FromBody] string message)
        {
            //var message = JsonSerializer.Serialize(request);

            await _producerService.ProduceAsync("topic_elham1", message);

            return Ok("message sent Successfully...");
        }
    }
}
