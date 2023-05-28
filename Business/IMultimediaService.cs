using Entities;

namespace Business
{
    public interface IMultimediaService
    {
        Task AddFilm(Film film);
        IEnumerable<Film> GetFilms();
        Task AddFilmToFavorites(Film film);
        /****************/
        Task AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Task AddSongToFavorites(Song song);
        /*****************/
        Task AddAudiobook(AudioBook audiobook);
        IEnumerable<AudioBook> GetAudiobooks();
        Task AddBookToFavorites(AudioBook audioBook);
        /******************/
        Task AddPodcast(Podcast podcast);
        IEnumerable<Podcast> GetPodcasts();
        Task AddPodcastToFavorites(Podcast podcast);
        /************************/
        IEnumerable<MultimediaContent> Search(string word);
    }
}