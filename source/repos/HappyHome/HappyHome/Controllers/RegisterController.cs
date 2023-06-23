using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace HappyHome.Controllers
{

    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[Controller]")]
    public class RegisterController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // attributed routing and method to access service
        [HttpPost, Route("~/api/register")]
        public async Task<IActionResult> Createlogin(Register registers)
        {
           

            var data = await _unitOfWork.RegisterService.register(registers);

            return Ok(data);



        }
    }
}
