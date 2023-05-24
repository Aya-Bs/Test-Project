using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class MultimediaContent
{
        [Key]
        public int id { get; set; }
        public string content_type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string length { get; set; }
        public string plateforme { get; set; }
        public MultimediaContent(int id, string content_type, string title, string description, string length, string plateforme)
        {
            this.id = id;
            this.content_type = content_type;
            this.length = length;
            this.title = title;
            this.description = description;
            this.plateforme = plateforme;

        }
        public MultimediaContent()
        {
            
        }
    }
}
