using DAL.Interfaces;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class MultimediaRepository : IMultimediaRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public MultimediaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAudiobook(AudioBook audiobook)
        {
            _dbContext.Add(audiobook);
            _dbContext.SaveChanges();
        }

        public Task AddBookToFavorites(AudioBook audioBook)
        {
            throw new NotImplementedException();
        }

        public async Task AddFilm(Film film)
        {
            _dbContext.Add(film);
            _dbContext.SaveChanges();
        }

        public Task AddFilmToFavorites(Film film)
        {
            throw new NotImplementedException();
        }

        public async Task AddPodcast(Podcast podcast)
        {
            _dbContext.Add(podcast);
            _dbContext.SaveChanges();
        }

        public Task AddPodcastToFavorites(Podcast podcast)
        {
            throw new NotImplementedException();
        }

        public async Task AddSong(Song song)
        {
            _dbContext.Add(song);
            _dbContext.SaveChanges();
        }

        public Task AddSongToFavorites(Song song)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<AudioBook> GetAudiobooks()
        {
            return _dbContext.AudioBooks.ToList();    
        }

        public IEnumerable<Film> GetFilms()
        {
            return _dbContext.Films.ToList();
        }

        public IEnumerable<Podcast> GetPodcasts()
        {
            return _dbContext.Podcasts.ToList();
        }

        public IEnumerable<Song> GetSongs()
        {
            return _dbContext.Songs.ToList();
        }

        //cette méthode permet de rechercher le contenu par le titre
        public IEnumerable<MultimediaContent> Search(string word)
        {
             List<Film> films = new List<Film>();
             List<Podcast> podcasts = new List<Podcast>();
             List<Song> songs = new List<Song>();
             List<AudioBook> audiobooks = new List<AudioBook>();
            List<MultimediaContent> content = new List<MultimediaContent>();
            
            foreach (Film f in _dbContext.Films)
            {
                if (f.title.Contains(word))
                    films.Add(f);

            }

            foreach (Song s in _dbContext.Songs)
            {
                if (s.title.Equals(word))
                    songs.Add(s);
            }

            foreach (AudioBook ab in _dbContext.AudioBooks)
            {
                if (ab.title.Equals(word))
                    audiobooks.Add(ab);

            }

            foreach (Podcast p in _dbContext.Podcasts)
            {
                if (p.title.Equals(word))
                    podcasts.Add(p);

            }
            //rassemble les résultats dans une seul liste
            content = films.OfType<MultimediaContent>().Concat(songs).Concat(podcasts).Concat(audiobooks).ToList();

            return content;



        }
    }
}
