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
