using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ActivityModel
{
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string IpAddress { get; set; }
       
       
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Color { get; set; }
        
    }

}
