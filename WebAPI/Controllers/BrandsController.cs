using Business.Abstracts;
using Business.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController<Brand,IBrandService>
    {
        IBrandService _brandService;
        public BrandsController(IBrandService brandService) : base(brandService)
        {
            this._brandService = brandService;
        }
    }
}
