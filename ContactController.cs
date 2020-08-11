using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using JopAppFinal.Models;

namespace JopAppFinal.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {

            return View();
        }

       

           

        public ActionResult EmailConfirmed()
        {

            return View();
        }
    }
}