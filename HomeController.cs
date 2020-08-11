using JopAppFinal.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace JopAppFinal.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} has sent you the following message: <br />" +
                    $"{cvm.Message} <strong> from the email address: </strong> {cvm.Email}";

                MailMessage m = new MailMessage("admin@christopherlmitchell.net", "christopher.lloyd.mitchell@gmail.com",
                    cvm.Subject, body);

                m.IsBodyHtml = true;

                m.Priority = MailPriority.High;

                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.christopherlmitchell.net");

                client.Credentials = new NetworkCredential("admin@christopherlmitchell.net", "@L5etjpLcnjgg");

                try
                {
                    client.Send(m);
                }
                catch (System.Exception ex)
                {

                    ViewBag.ErrorMessage = "There was a problem, try again or see message details below...<br />" +
                        ex.StackTrace;

                    return View("Contact", cvm);
                }
                return View("EmailConfirmed", cvm);

            }
            return View(cvm);


        }
    }
}
