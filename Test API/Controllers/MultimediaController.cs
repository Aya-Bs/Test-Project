using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IEnumerable<MultimediaContent> Search([FromQuery] string word)
        {
            var result = multimediaService.Search(word);
            return result;
        }

        [HttpGet]
        [Route("GetFilByName")]
        public Task<Film> GetFilmByName(string name)
        {
            return multimediaService.GetFilmByName(name);

        }
        [HttpGet]
        [Route("GetAudiobookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var audiobook = multimediaService.GetBookById(id);
            if (audiobook != null)
                return Ok(audiobook);
            return NotFound();
        }
        [HttpGet]
        [Route("GetFilmById")]
        public Task<Film> GetFilmById(int id)
        {
            return multimediaService.GetFilmById(id);

        }
        [HttpGet]
        [Route("GetSongById")]

        public Task<Song> GetSongById(int id)
        {
            return multimediaService.GetSongById(id);

        }
        [HttpGet]
        [Route("GetPodcastById")]
        public async Task<IActionResult> GetPodcastById(int id)
        {
            var podcast = multimediaService.GetPodcastById(id);
            if (podcast != null)
                return Ok(podcast);
            return NotFound();
        }
        [HttpGet]
        [Route("api/songs/{id}")]

        // Fetch the song file based on the provided ID or filename
        public async Task<IActionResult> StreamSong(int id)
        {
            // Retrieve the song data based on the provided ID
            byte[] songData = await multimediaService.RetrieveSongDataAsync(id);

            // Return the song data as a stream
            Stream songStream = new MemoryStream(songData);
            return File(songStream, "audio/mpeg"); // Set the appropriate content type for the song
        }
        [HttpGet]
        [Route("api/films/{id}")]

        // Fetch the song file based on the provided ID or filename
        public IActionResult StreamFilm(int id)
        {
            var film = multimediaService.GetFilmById(id);
            if (film == null)
            {
                return NotFound("Movie not found.");
            }
            var filmPath = multimediaService.GetFilmPath(id);
            // Retrieve the song data based on the provided ID
            if (!System.IO.File.Exists(filmPath))
                return NotFound("Movie file not found.");
            var fileStream = new FileStream(filmPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(fileStream, "video/mp4");

        }
        [HttpGet]
        [Route("api/podcasts/{id}")]

        // Fetch the song file based on the provided ID or filename
        public async Task<IActionResult> StreamPodcast(int id)
        {
            // Retrieve the song data based on the provided ID
            byte[] podcastData = await multimediaService.RetrievePodcastDataAsync(id);

            // Return the song data as a stream
            Stream podcastStream = new MemoryStream(podcastData);
            return File(podcastStream, "audio/mpeg"); // Set the appropriate content type for the song
        }
        [HttpGet]
        [Route("api/audiobooks/{id}")]

        // Fetch the song file based on the provided ID or filename
        public async Task<IActionResult> StreamAudiobook(int id)
        {
            // Retrieve the song data based on the provided ID
            byte[] audiobookData = await multimediaService.RetrieveBookDataAsync(id);

            // Return the song data as a stream
            Stream audiobookStream = new MemoryStream(audiobookData);
            return File(audiobookData, "audio/mpeg"); // Set the appropriate content type for the song
        }
    }


        
}
