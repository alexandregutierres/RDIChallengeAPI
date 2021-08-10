using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RDIChallengeAPI.Controllers;
using RDIChallengeAPI.Models;
using RDIChallengeAPI.Repositories;
using RDIChallengeAPI.Repositories.Interfaces;
using RDIChallengeAPI.Services;
using RDIChallengeAPI.Services.Interfaces;
using Xunit;

namespace RDIChallengeAPI_Test
{
    public class UnitTest1
    {
        private readonly ICustomerServices _customerServices;

        public UnitTest1()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<ITokenServices, TokenServices>();

            var serviceProvider = services.BuildServiceProvider();
            _customerServices = serviceProvider.GetService<ICustomerServices>();
        }

        [Fact]
        public void GiveUserMustAddAndReturnToken()
        {
            //arrange
            var controller = new CustomersController(_customerServices);

            CustomerBody customerBody = new CustomerBody
            {
                CustomerId = 123,
                CardNumber = 4916898414075509,
                CVV = 512
            };

            //act
            var ret = controller.AddCustomer(customerBody);

            //assert
            Assert.IsType<OkObjectResult>(ret);

            Assert.NotNull(customerBody.Token);
        }

        [Fact]
        public void FindCustomerById()
        {
            //arrange 
            var customerController = new CustomersController(_customerServices);
            var validateController = new ValidateController(_customerServices);

            CustomerBody customerBody = new CustomerBody
            {
                CustomerId = 123,
                CardNumber = 4916898414075509,
                CVV = 512
            };

            //act
            var retCustomer = customerController.AddCustomer(customerBody);

            CustomerValidate customerValidate = new CustomerValidate
            {
                CustomerId = customerBody.CustomerId,
                CardId = customerBody.CardId,
                CVV = customerBody.CVV,
                Token = customerBody.Token
            };
            var retValidate = validateController.ValidateUser(customerValidate);

            //assert

            Assert.IsType<OkObjectResult>(retValidate);

        }


    }
}
