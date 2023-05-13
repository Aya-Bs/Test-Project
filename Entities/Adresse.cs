using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Adresse")]
    public class Adresse
    {
        [Key]
        public int idPays { get; set; }
        public string nomPays { get; set; }

        public Adresse(int idPays, string nomPays)
        {
            this.idPays = idPays;
            this.nomPays = nomPays;
        }
    }
}