using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMultimediaRepository
    {
        Task AddFilm(Film film);
        IEnumerable<Film> GetFilms();
        Task AddFilmToFavorites(Film film);
        Task<Film> GetFilmByName(string name);
        Task<Film> GetFilmById(int id);
        string GetFilmPath(int id);
        /****************/
        Task AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Task<Song> GetSongById(int id);
        Task AddSongToFavorites(Song song);
        string GetSongPath(int id);
        /*****************/
        Task AddAudiobook(AudioBook audiobook);
        IEnumerable<AudioBook> GetAudiobooks();
        Task AddBookToFavorites(AudioBook audioBook);
        Task<AudioBook> GetBookById(int id);
        string GetAudiobookPath(int id);
        /******************/
        Task AddPodcast(Podcast podcast);
        IEnumerable<Podcast> GetPodcasts();
        Task AddPodcastToFavorites(Podcast podcast);
        Task<Podcast> GetPodcastById(int id);
        string GetPodcastPath(int id);
        
        /************************/
        IEnumerable<MultimediaContent> Search(string word);


    }
}
