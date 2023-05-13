using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AbonnementController : ControllerBase
    {
        IAbonnementRepository abonnementRepository;
        public AbonnementController(IAbonnementRepository abonnementRepo)
        {
            abonnementRepository = abonnementRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Abonnement> GetAbonnements()
        {
            return abonnementRepository.GetAbonnements();
        }
        [HttpGet]
        [Route("GetAbonnementById")]
        public async Task<IActionResult> GetAbonnementById(int id)
        {
            var abonnement = abonnementRepository.GetAbonnement(id);
            if (abonnement == null)
            {
                return NotFound();
            }
            return Ok(abonnement);

        }

        [HttpPost]
        [Route("AddAbonnement")]
        public async Task<IActionResult> AddAbonnement(Abonnement abonnement)
        {
            abonnementRepository.AddAbonnement(abonnement);
            return Created("successful", abonnement);
        }

        [HttpPut]
        [Route("UpdateAbonnement")]
        public async Task<IActionResult> UpdateOffre(Abonnement abonnement)
        {
            abonnementRepository.UpdateAbonnement(abonnement);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteAbonnement")]
        public JsonResult DeleteAbonnement(int id)
        {
            var result = abonnementRepository.DeleteAbonnement(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
