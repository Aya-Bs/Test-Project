using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Subscriber")]
    public class Subscriber
    {

        [Key]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
    }
}
