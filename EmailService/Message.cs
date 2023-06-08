using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EmailService
{
    public class Message
    {
        
        private string? email;
        private string v;
        private object msg;
        private string? emailfrom;
        private MailboxAddress From;

        
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content, string from)
        {
            From = new MailboxAddress("from",from) ;
            
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("x",x)));
            Subject = subject;
            Content = content;
        }

        public Message(string? email, string subject, string content, string emailfrom)
        {
            this.email = email;
            this.v = v;
            this.msg = msg;
            this.emailfrom = emailfrom;
        }
    }
}
