using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Podcast")]
    public class Podcast : MultimediaContent
{
        public Podcast(int id, string title, string description, string length, string plateforme)
        {
            this.id = id;
            this.content_type = "podcast";
            this.length = length;
            this.title = title;
            this.description = description;
            this.plateforme = plateforme;
        }
        public Podcast()
        {

        }
    }
}
