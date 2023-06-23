using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace HappyHome.Controllers
{

    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // attributed routing and method to access service
        [HttpPost, Route("~/api/admin/user")]
        public async Task<IActionResult> Createuser(User users)
        {


            var data = await _unitOfWork.UserService.user(users);

            return Ok(data);



        }

    }
}
