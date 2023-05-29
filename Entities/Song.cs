using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Song")]
    public class Song : MultimediaContent
{
        public string artist { get; set; }
        public string[] lyrics { get; set; }
    public Song(int id, string title, string description, string length, string plateforme,string route, string artist, string[] lyrics)
    {
        this.id = id;
            this.title = title;
            this.content_type = "song";
        this.length = length;
        
        this.description = description;
        this.plateforme = plateforme;
            this.route = route;
            this.artist = artist;
            this.lyrics = lyrics;
        }
    public Song()
    {

    }
}
}
