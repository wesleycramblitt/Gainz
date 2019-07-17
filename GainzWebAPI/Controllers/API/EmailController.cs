using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;

namespace GainzWebAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController
    {
        public static async Task<int> SubscribeEmail(string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, 
                "https://us20.api.mailchimp.com/3.0/lists/7ee61bb308/members");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Add("Authorization","Basic " + Startup.MailChimpAuth);
            request.Headers.Add("User-Agent", "Gainz");


            request.Content = new StringContent("{\"email_address\":\""+email+"\",\"status\":\"subscribed\"}",
                                    Encoding.UTF8,
                                    "application/json");

            var client = new HttpClient();

            var response = await client.SendAsync(request);


            return Convert.ToInt32(response.StatusCode);
            
        }


        [HttpPost]
        public async Task<ActionResult> SendPDFToEmailAndSubscribe(EmailPDF emailPDF)
        {
            var subscribeStatus = await SubscribeEmail(emailPDF.Email);

            //No error handling for now.

            emailPDF.Datauri = emailPDF.Datauri.Replace("data:application/pdf;filename=generated.pdf;base64,", "");
            byte[] pdfBytes;
            try
            {
                pdfBytes = Convert.FromBase64String(emailPDF.Datauri);

                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress("wcramblitt@gmail.com");

                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
                smtp.UseDefaultCredentials = false; // [3] Changed this
                smtp.Credentials = new NetworkCredential("wcramblitt@gmail.com", "M0Pa1N31Kung");  // [4] Added this. Note, first parameter is NOT string.
                smtp.Host = "smtp.gmail.com";

                //recipient address
                mail.To.Add(new MailAddress(emailPDF.Email));

                //Formatted mail body
                mail.IsBodyHtml = true;
                string body = "Your custom workout routine is attached. Enjoy :)";

                mail.Body = body;

                Attachment att = new Attachment(new MemoryStream(pdfBytes), "routine.pdf");
                mail.Attachments.Add(att);

                smtp.Send(mail);

            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }



            return new StatusCodeResult(200);
            

        }

    }

    public class EmailPDF
    {
        public string Email { get; set; }
        public string Datauri { get; set; }
    }
}
