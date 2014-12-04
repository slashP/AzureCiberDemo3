using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureCiberDemo3.Controllers
{
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Routing;

    using Azure;

    using Mail.Services;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello Poznan from Oslo!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("images/{container}")]
        public ActionResult Images(string container)
        {
            var urls = new AzureBlobService().GetUrls(container);
            return View(urls);
        }

        [Route("imageUpload/{container}")]
        public async Task<string> Upload(string container)
        {
            await new AzureBlobService().UploadAsync(container, Request.Files[0].InputStream);
            return "ok";
        }

        [Route("sendEmail")]
        public string SendMail()
        {
            new SendGridService().Send("per-kristian.helland@ciber.com", "Christmas comes early", "Komplett are going to Poznan!");
            return "Ok";
        }

        [Route("loaderio-d86e80e4a093deed90cc57140249e979")]
        public ActionResult Asdf()
        {
            return new FileContentResult(
                Encoding.UTF8.GetBytes("loaderio-d86e80e4a093deed90cc57140249e979"),
                "text/plain");
        }
    }
}