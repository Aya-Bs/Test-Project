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

        public IEnumerable<Film> GetFilms()
        {
            return multimediaRepository.GetFilms();
        }

        public IEnumerable<Podcast> GetPodcasts()
        {
            return multimediaRepository.GetPodcasts();
        }

        public IEnumerable<Song> GetSongs()
        {
            return multimediaRepository.GetSongs();
        }

        public IEnumerable<MultimediaContent> Search(string word)
        {
            return multimediaRepository.Search(word);
        }
    }
}
