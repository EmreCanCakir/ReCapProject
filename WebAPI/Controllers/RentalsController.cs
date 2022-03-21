using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : BaseController<Rental, IRentalService>
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService) : base(rentalService)
        {
            _rentalService = rentalService;
        }
    }
}
