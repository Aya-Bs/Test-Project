using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Film")]
    public class Film : MultimediaContent
{
        public string[] actors { get; set; }
        public string rating { get; set; }
        public string topic { get; set; }
        public Film(int id,  string title, string description, string length, string plateforme, string route, string[] actors, string rating, string topic,string photo)
        {
            this.id = id;
            this.content_type = "film";
            this.length = length;
            this.title = title;
            this.description = description;
            this.plateforme = plateforme;
            this.route = route;
            this.actors = actors;
            this.rating = rating;
            this.topic = topic;
            this.photo = photo;
        }
        public Film()
        {
            
        }
    }
}
