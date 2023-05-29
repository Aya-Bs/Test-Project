using Entities;
using System.Threading.Tasks;

namespace Business
{
    public interface IMultimediaService
    {
        Task AddFilm(Film film);
        IEnumerable<Film> GetFilms();
        Task AddFilmToFavorites(Film film);
        Task<Film> GetFilmByName(string name);
        Task<Film> GetFilmById(int id);
        string GetFilmPath(int id);
        Task<byte[]> RetrieveFilmDataAsync(int id);
        /****************/
        Task AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Task AddSongToFavorites(Song song);
        Task<Song> GetSongById(int id);
        string GetSongPath(int id);

        Task<byte[]> RetrieveSongDataAsync(int id);

        /*****************/
        Task AddAudiobook(AudioBook audiobook);
        IEnumerable<AudioBook> GetAudiobooks();
        Task AddBookToFavorites(AudioBook audioBook);
        Task<AudioBook> GetBookById(int id);
        string GetBookPath(int id);
        Task<byte[]> RetrieveBookDataAsync(int id);
        /******************/
        Task AddPodcast(Podcast podcast);
        IEnumerable<Podcast> GetPodcasts();
        Task AddPodcastToFavorites(Podcast podcast);
        Task<Podcast> GetPodcastById(int id);
        string GetPodcastPath(int id);
        Task<byte[]> RetrievePodcastDataAsync(int id);
        /************************/
        IEnumerable<MultimediaContent> Search(string word);
    }
}