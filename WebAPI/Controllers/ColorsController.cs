using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController<Color,IColorService>
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService):base(colorService)
        {
            _colorService = colorService;
        }
        
    }
}
