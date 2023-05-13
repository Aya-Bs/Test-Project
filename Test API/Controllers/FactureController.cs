using DAL.Classes;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        IFactureRepository factureRepository;

        public FactureController(IFactureRepository factureRepo)
        {
            factureRepository = factureRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Facture> GetFactures()
        {
            return factureRepository.GetFactures();
        }
        [HttpGet]
        [Route("GetFactureById")]
        public async Task<IActionResult> GetOffreById(int id)
        {
            var facture = factureRepository.GetFacture(id);
            if (facture == null)
            {
                return NotFound();
            }
            return Ok(facture);

        }

        [HttpPost]
        [Route("AddFacture")]
        public async Task<IActionResult> AddFacture(Facture facture)
        {
            factureRepository.AddFacture(facture);
            return Created("successful", facture);
        }

        [HttpPut]
        [Route("UpdateFacture")]
        public async Task<IActionResult> UpdateFacture(Facture facture)
        {
            factureRepository.UpdateFacture(facture);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteFacture")]
        public JsonResult DeleteFacture(int id)
        {
            var result = factureRepository.DeleteFacture(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
