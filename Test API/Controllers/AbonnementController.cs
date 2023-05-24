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
    public class AbonnementController : ControllerBase
    {
        
        private readonly IAbonnementService abonnementService;
        public AbonnementController(IAbonnementService abonnementServ)
        {
            abonnementService = abonnementServ;
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Abonnement> GetAbonnements()
        {
            return abonnementService.GetAbonnements();
        }
        [HttpGet]
        [Route("GetAbonnementById")]
        public async Task<IActionResult> GetAbonnementById(int id)
        {
            var abonnement = abonnementService.GetAbonnement(id);
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
            abonnementService.AddAbonnement(abonnement);
            return Created("successful", abonnement);
        }

        [HttpPut]
        [Route("UpdateAbonnement")]
        public async Task<IActionResult> UpdateOffre(Abonnement abonnement)
        {
            abonnementService.UpdateAbonnement(abonnement);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteAbonnement")]
        public JsonResult DeleteAbonnement(int id)
        {
            var result = abonnementService.DeleteAbonnement(id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        [Route("GetAbonnementByContenu")]
        public List<Abonnement> GetAbonnementByContenu([FromQuery] string word)
        {

            return abonnementService.GetAbonnementByContenu(word);
        }
    }

}
