using Microsoft.AspNetCore.Mvc;
using RDIChallengeAPI.Models;
using RDIChallengeAPI.Services.Interfaces;

namespace RDIChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidateController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
 
        public ValidateController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }


        [HttpPost]
        public IActionResult ValidateUser([FromBody] CustomerValidate model)
        {
            if (ModelState.IsValid) 
            {
                var customerOk = _customerServices.IsValid(model);
                return Ok(customerOk);
            }
            return BadRequest();
        }

    }
}
