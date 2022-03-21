using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController<Car,ICarService>
    {
        ICarService _carService;

        public CarsController(ICarService carService):base(carService)
        {
            _carService = carService;
        }
        
        [HttpGet("getCarsByColorId")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpGet]
        public IActionResult GetCarDetailDtos()
        {
            var result = _carService.GetCarDetailDtos();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
