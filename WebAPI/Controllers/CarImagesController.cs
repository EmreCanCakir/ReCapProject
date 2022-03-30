using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseController<CarImage,ICarImagesService>
    {
        private ICarImagesService _carImagesService;
        public CarImagesController(ICarImagesService service) : base(service)
        {
            _carImagesService = service;
        }

        [HttpPost("add1")]
        public IActionResult Add1(IFormFile file,[FromForm]CarImage entity)
        {
            var result = _carImagesService.Add1(file,entity);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("delete1")]
        public IActionResult Delete1([FromForm]CarImage entity)
        {
            var result = _carImagesService.Delete1(entity);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("update1")]
        public IActionResult Update1(IFormFile file,[FromForm]CarImage entity)
        {
            var result = _carImagesService.Update1(file,entity);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId([FromForm]int carId)
        {
            var result = _carImagesService.GetByCarId(carId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
