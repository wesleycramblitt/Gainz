using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace GainzWebAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailChimpController
    {
        [HttpPost]
        public async Task<ActionResult> SubscribeEmail([FromBody] string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, 
                "https://us20.api.mailchimp.com/3.0/lists/7ee61bb308/members");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Add("Authorization","Basic " + Startup.MailChimpAuth);
            //request.Headers.Add("User-Agent", "Gainz");


            request.Content = new StringContent("{\"email_address\":\""+email+"\",\"status\":\"subscribed\"}",
                                    Encoding.UTF8,
                                    "application/json");

            var client = new HttpClient();

            var response = await client.SendAsync(request);


            return new JsonResult(response.ReasonPhrase)
            {
                StatusCode = Convert.ToInt32(response.StatusCode)

            };
            
        }
    }
}
