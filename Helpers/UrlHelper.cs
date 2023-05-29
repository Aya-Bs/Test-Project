using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helpers
{
    public static class UrlHelper
    {
        //generer un url qu'on va envoyer au utilisateur pour récuperer son mdp
        public static string AbsoluteUrl(this IHttpContextAccessor httpContextAccessor, string relativeUrl, object parameters = null)
        {
            var request = httpContextAccessor.HttpContext.Request;
            var url = new Uri(new Uri($"{request.Scheme}://{request.Host.Value}"), relativeUrl).ToString();
            if (parameters != null)
            {
                url = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(url, ToDictionary(parameters));
            }
            return url;
        }

        private static Dictionary<string, string> ToDictionary(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject < Dictionary<string, string>>(json);
        }
    }
}
