using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer, ICustomerService>
    {
        ICustomerService _customersService;
        public CustomersController(ICustomerService customerService) : base(customerService)
        {
            _customersService = customerService;
        }
    }
}
