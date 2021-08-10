using Microsoft.AspNetCore.Mvc;
using RDIChallengeAPI.Models;
using RDIChallengeAPI.Services.Interfaces;

namespace RDIChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerBody model)
        {
            if (ModelState.IsValid)
            {
                _customerServices.Add(model);
                return Ok(model.ToApi()); 
            }
            return BadRequest();
        }



    }
}
