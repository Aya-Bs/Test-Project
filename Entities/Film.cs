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
        public Film(int id,  string title, string description, string length, string plateforme)
        {
            this.id = id;
            this.content_type = "film";
            this.length = length;
            this.title = title;
            this.description = description;
            this.plateforme = plateforme;
        }
        public Film()
        {
            
        }
    }
}
