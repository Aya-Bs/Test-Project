using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class Message
    {
        private string? email;
        private string v;
        private object msg;

        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("x",x)));
            Subject = subject;
            Content = content;
        }

        public Message(string? email, string subject, string content)
        {
            this.email = email;
            this.v = v;
            this.msg = msg;
        }
    }
}
