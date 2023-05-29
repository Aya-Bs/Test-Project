using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("AudioBook")]
    public class AudioBook : MultimediaContent
{
        public string author { get; set; }
        public string rating { get; set; }
        public string topic { get; set; }
        public AudioBook(int id, string title, string description, string length, string plateforme, string route,string author, string rating,string topic)
        {
            this.id = id;
            this.content_type = "audioBook";
            this.length = length;
            this.title = title;
            this.description = description;
            this.plateforme = plateforme;
            this.route = route;
            this.author = author;
            this.rating = rating;
            this.topic = topic;
        }
        public AudioBook()
        {

        }
    }
}
