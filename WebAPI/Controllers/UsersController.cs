using Business.Abstracts;
using Core.Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User,IUserService>
    {
       IUserService _userService;

        public UsersController(IUserService userService):base(userService)
        {
            _userService = userService;
        }
    }
}
