using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MultimediaService : IMultimediaService
    {
        public readonly IMultimediaRepository multimediaRepository;
        public MultimediaService(IMultimediaRepository multimediaRepo)
        {
            multimediaRepository = multimediaRepo;
            
        }
        public async Task AddAudiobook(AudioBook audiobook)
        {
            multimediaRepository.AddAudiobook(audiobook);
        }

        public Task AddBookToFavorites(AudioBook audioBook)
        {
            throw new NotImplementedException();
        }

        public async Task AddFilm(Film film)
        {
            multimediaRepository.AddFilm(film);
        }

        public Task AddFilmToFavorites(Film film)
        {
            throw new NotImplementedException();
        }

        public async Task AddPodcast(Podcast podcast)
        {
            multimediaRepository.AddPodcast(podcast);
        }

        public Task AddPodcastToFavorites(Podcast podcast)
        {
            throw new NotImplementedException();
        }

        public async Task AddSong(Song song)
        {
            multimediaRepository.AddSong(song);
        }

        public Task AddSongToFavorites(Song song)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AudioBook> GetAudiobooks()
        {
            return multimediaRepository.GetAudiobooks();
        }

        public Task<AudioBook> GetBookById(int id)
        {
            return multimediaRepository.GetBookById(id);
        }

        public string GetBookPath(int id)
        {
            return multimediaRepository.GetAudiobookPath(id);
        }

        public Task<Film> GetFilmById(int id)
        {
            return multimediaRepository.GetFilmById(id);
        }

        public Task<Film> GetFilmByName(string name)
        {
            return multimediaRepository.GetFilmByName(name);
        }

        public string GetFilmPath(int id)
        {
            return multimediaRepository.GetFilmPath(id);
        }

        public IEnumerable<Film> GetFilms()
        {
            return multimediaRepository.GetFilms();
        }

        public  Task<Podcast> GetPodcastById(int id)
        {
            return multimediaRepository.GetPodcastById(id);
        }

        public string GetPodcastPath(int id)
        {
            return multimediaRepository.GetPodcastPath(id);
        }

        public IEnumerable<Podcast> GetPodcasts()
        {
            return multimediaRepository.GetPodcasts();
        }

        public Task<Song> GetSongById(int id)
        {
            return multimediaRepository.GetSongById(id);
        }

        public string GetSongPath(int id)
        {
            return multimediaRepository.GetSongPath(id);
        }
        

        public IEnumerable<Song> GetSongs()
        {
            return multimediaRepository.GetSongs();
        }

        public async Task<byte[]> RetrieveBookDataAsync(int id)
        {
            string filePath = this.GetBookPath(id);
            byte[] audiobookData = await File.ReadAllBytesAsync(filePath);

            return audiobookData;
        }

        public async Task<byte[]> RetrieveFilmDataAsync(int id)
        {
            string filePath = this.GetFilmPath(id);
            byte[] filmData = await File.ReadAllBytesAsync(filePath);

            return filmData;
        }

        public async Task<byte[]> RetrievePodcastDataAsync(int id)
        {
            string filePath = this.GetPodcastPath(id);
            byte[] podcastData = await File.ReadAllBytesAsync(filePath);

            return podcastData;
        }

        public async Task<byte[]> RetrieveSongDataAsync(int id)
        {
            string filePath = this.GetSongPath(id);
            byte[] songData = await File.ReadAllBytesAsync(filePath);

            return songData;
        }

        public IEnumerable<MultimediaContent> Search(string word)
        {
            return multimediaRepository.Search(word);
        }

        
    }
}
