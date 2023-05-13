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
        ICarteRepository carteRepository;
        public CarteController(ICarteRepository carteRepo)
        {
            carteRepository = carteRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<CartePaiement> GetCartes()
        {
            return carteRepository.GetCartes();
        }
        [HttpGet]
        [Route("GetCarteById")]
        public async Task<IActionResult> GetCarteById(int id)
        {
            var carte = carteRepository.GetCarte(id);
            if (carte == null)
            {
                return NotFound();
            }
            return Ok(carte);

        }

        [HttpPost]
        [Route("AddCarte")]
        public async Task<IActionResult> AddCarte(CartePaiement carte)
        {
            carteRepository.AddCarte(carte);
            return Created("successful", carte);
        }

        [HttpPut]
        [Route("UpdateCarte")]
        public async Task<IActionResult> UpdateCarte(CartePaiement carte)
        {
            carteRepository.UpdateCarte(carte);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCarte")]
        public JsonResult DeleteCarte(int id)
        {
            var result = carteRepository.DeleteCarte(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
