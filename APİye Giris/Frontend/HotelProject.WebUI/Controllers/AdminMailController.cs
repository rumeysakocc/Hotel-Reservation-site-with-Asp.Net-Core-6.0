using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //kimden olacağı
            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "oylesine.biri2047@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
            //kime olacağı
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //mesaj içeriği
            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("oylesine.biri2047@gmail.com", "tjzymstlchxpbven");
            client.Send(mimeMessage);
            client.Disconnect(true);


            return View();
        }
    }
}
