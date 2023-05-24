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
    public Song(int id, string title, string description, string length, string plateforme)
    {
        this.id = id;
        this.content_type = "song";
        this.length = length;
        this.title = title;
        this.description = description;
        this.plateforme = plateforme;
        }
    public Song()
    {

    }
}
}
