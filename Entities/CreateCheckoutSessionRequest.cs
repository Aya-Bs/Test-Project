using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Entities
{
    public class CreateCheckoutSessionRequest
{
       
            [JsonProperty("priceId")]
            public string PriceId { get; set; }
        
    }
}
