using Entities;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

         public void SendEmail(Message message)
         {
             var emailMessage = CreateEmailMessage(message);
             Send(emailMessage);
         }
         //connecter au serveur email avec SmtpClient, s'authentifier, et envoyer le message 
         private void Send(MimeMessage mailMessage)
         {
             using (var client = new SmtpClient())
             {
                 try
                 {
                     client.CheckCertificateRevocation = false;
                     client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                     client.AuthenticationMechanisms.Remove("XOAUTH2");
                     client.Authenticate("eyaboukh@gmail.com", "dxkmafsjyixzbxwm");
                     client.Send(mailMessage);
                 }
                 catch
                 {
                     //log an error message or throw an exception or both.
                     throw;
                 }
                 finally
                 {
                     client.Disconnect(true);
                     client.Dispose();
                 }
             }
         }
         //on va créer un message de type MimeMessage et on va configurer les propriétés
         private MimeMessage CreateEmailMessage(Message message)
         {
             User user = new User();
             var emailMessage = new MimeMessage();
             emailMessage.From.Add(new MailboxAddress("email",user.email));

             emailMessage.To.AddRange(message.To);
             emailMessage.Subject = message.Subject;
             emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
             return emailMessage;
         }

        public async Task SendEmailAsync(Message message)
         {
             var mailMessage = CreateEmailMessage(message);
             await SendAsync(mailMessage);
         }

         private async Task SendAsync(MimeMessage mailMessage)
         {
             using (var client = new SmtpClient())
             {
                 try
                 {
                     client.CheckCertificateRevocation = false;   
                     await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                     client.AuthenticationMechanisms.Remove("XOAUTH2");
                     await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                     await client.SendAsync(mailMessage);
                 }
                 catch
                 {
                     //log an error message or throw an exception, or both.
                     throw;
                 }
                 finally
                 {
                     await client.DisconnectAsync(true);
                     client.Dispose();
                 }
             }
         }
    }
}
