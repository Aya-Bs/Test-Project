using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    
    public class PasswordController : Controller
    {
        private readonly IUserService userService;
        public PasswordController(IUserService userServ)
        {
            userService = userServ;
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            return View(model);
        }
       /* [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody ]ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.ResetPassword(model);
                if (result.isValid)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
                
            }return BadRequest("Fail");

        }*/
       /* [HttpPost]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }*/
    }
}
