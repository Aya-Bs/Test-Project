using Business;
using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CarteController : ControllerBase
    {
        readonly ICarteService carteService;
        public CarteController(ICarteService carteServ)
        {
            carteService = carteServ;
        }
       
        

        [HttpPost]
        [Route("AddCarte")]
        public async Task<IActionResult> AddCarte(CartePaiement carte)
        {
            carteService.AddCarte(carte);
            return Created("successful", carte);
        }

        [HttpPut]
        [Route("UpdateCarte")]
        public async Task<IActionResult> UpdateCarte(CartePaiement carte)
        {
            carteService.UpdateCarte(carte);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCarte")]
        public JsonResult DeleteCarte(int id)
        {
            var result = carteService.DeleteCarte(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
