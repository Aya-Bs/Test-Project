using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modele_de_domaine;
using Adresse = Entities.Adresse;

namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        IAdresseRepository adresseRepository;
        public AdresseController(IAdresseRepository adresseRepo)
        {
            adresseRepository = adresseRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Adresse> GetAdresses()
        {
            return adresseRepository.GetAdresses();
        }
        [HttpGet]
        [Route("GetAdresseById")]
        public async Task<IActionResult> GetAdresseById(int id)
        {
            var adresse = adresseRepository.GetAdresse(id);
            if (adresse == null)
            {
                return NotFound();
            }
            return Ok(adresse);

        }

        [HttpPost]
        [Route("AddAdresse")]
        public async Task<IActionResult> AddAdresse(Adresse adresse)
        {
            adresseRepository.AddAdresse(adresse);
            return Created("successful", adresse);
        }

        [HttpPut]
        [Route("UpdateAdresse")]
        public async Task<IActionResult> UpdateAdresse(Adresse adresse)
        {
            adresseRepository.UpdateAdresse(adresse);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteAdresse")]
        public JsonResult DeleteAdresse(int id)
        {
            var result = adresseRepository.DeleteAdresse(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
