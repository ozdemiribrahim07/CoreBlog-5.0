using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Concrete
{
    public class Smtpp  // SMTP mail gönderme işlemi için gerekli olan class.
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }
        public string SenderMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



    }
}
