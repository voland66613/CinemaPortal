﻿using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace CinemaPortal_ASP.NET_Core.Helpers
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email,string subject,string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Site administration", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using(var client=new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("login@yandex.ru", "password");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
