using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Bibliography;
using Business;
using DocumentFormat.OpenXml.Office2021.Excel.RichDataWebImage;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace Test_API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OffreController : ControllerBase
    {
        private readonly IOffreRepository offreRepository;


        //assign the private var offreRepository to the injected car offreRepo
        public OffreController(IOffreRepository offreRepo)
        {
            offreRepository = offreRepo;

        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Offre> GetOffres()
        {
            return offreRepository.GetOffres();
        }

        [HttpGet]
        [Route("GetOffreById")]
        public async Task<IActionResult> GetOffreById(int id)
        {
            var offre = offreRepository.GetOffre(id);
            if (offre == null)
            {
                return NotFound();
            }
            return Ok(offre);

        }

        [HttpPost]
        [Route("AddOffre")]
        public async Task<IActionResult> AddOffre(Offre offre)
        {
            offreRepository.AddOffre(offre);
            return Created("successful", offre);
        }

        [HttpPut]
        [Route("UpdateOffre")]
        public async Task<IActionResult> UpdateOffre(Offre offre)
        {
            offreRepository.UpdateOffre(offre);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteOffre")]
        public async Task<IActionResult> DeleteOffre(int id)
        {



            if (id != null) {
                await offreRepository.DeleteOffre(id);
                return Ok(new { message = "Offre deleted" }); }
            else
            {
                return NotFound("cette offre n'exixte pas");
            }

        }



        [HttpGet]
        [Route("GetOffreByContenu")]
        public List<Offre> GetOffreByContenu([FromQuery] string word)
        {
             
            return offreRepository.GetOffreByContenu(word);
        }



    }
}
