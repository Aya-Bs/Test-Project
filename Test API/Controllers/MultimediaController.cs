using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultimediaController : ControllerBase
    {
        public readonly IMultimediaService multimediaService;
        public MultimediaController(IMultimediaService multimediaServ)
        {
            multimediaService = multimediaServ;
            
        }
        [HttpGet]
        [Route("GetAllFilms")]
        public IEnumerable<Film> GetFilms()
        {
            return multimediaService.GetFilms();

        }
        /***************/
        [HttpGet]
        [Route("GetAllSongs")]
        public IEnumerable<Song> GetSongs()
        {
            return multimediaService.GetSongs();

        }
        /*************/
        [HttpGet]
        [Route("GetAllBooks")]
        public IEnumerable<AudioBook> GetAudiobooks()
        {
            return multimediaService.GetAudiobooks();

        }
        /******************/
        [HttpGet]
        [Route("GetAllPodcasts")]
        public IEnumerable<Podcast> GetPodcasts()
        {
            return multimediaService.GetPodcasts();

        }
        /************************/
        [HttpPost]
        [Route("AddFilm")]
        public async Task<IActionResult> AddFilm(Film film)
        {
            multimediaService.AddFilm(film);
            return Created("successful(", film);
        }
        /****************/
        [HttpPost]
        [Route("AddSong")]
        public async Task<IActionResult> AddSong(Song song)
        {
            multimediaService.AddSong(song);
            return Created("successful(", song);
        }
        /****************/
        [HttpPost]
        [Route("AddAudiobook")]
        public async Task<IActionResult> AddAudiobook(AudioBook audioBook)
        {
            multimediaService.AddAudiobook(audioBook);
            return Created("successful(", audioBook);
        }
        /*******************/
        [HttpPost]
        [Route("AddPodcast")]
        public async Task<IActionResult> AddPodcast(Podcast podcast)
        {
            multimediaService.AddPodcast(podcast);
            return Created("successful(", podcast);
        }
        /********************/
        [HttpGet]
        [Route("Search")]
        public IEnumerable<MultimediaContent> Search([FromQuery]string word)
        {
            var result = multimediaService.Search(word);
            return result;
        }

    }
}
