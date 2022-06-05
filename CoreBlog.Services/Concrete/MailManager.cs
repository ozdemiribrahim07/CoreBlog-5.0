using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Concrete;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Concrete
{
    public class MailManager : IEMailService
    {
        private readonly Smtpp _smtpp;

        public MailManager(Smtpp smtpp)
        {
            _smtpp = smtpp;
        }

        public MailManager(IOptions<Smtpp> options)
        {
            _smtpp = options.Value;


        }

        public ISonuc Gonder(ContactSendDto contactSendDto)  // kullanıcı mail mesajı gönderdiğinde ilk önce appsetting yazdığımız mailden bize mesaj gelir.
        {
            MailMessage mesaj = new MailMessage
            {
                From = new MailAddress(_smtpp.SenderMail),
                To = { new MailAddress(contactSendDto.Mail) },
                Subject = contactSendDto.SubjectDesc,
                IsBodyHtml = true,
                Body = contactSendDto.Mail



            };

            SmtpClient smtpClient = new SmtpClient
            {
                EnableSsl = true,
                Host = _smtpp.Server,
                Port = _smtpp.Port,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpp.Username, _smtpp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network



            };

            smtpClient.Send(mesaj);

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, "Başarılı!");

        }

        public ISonuc GonderMail(ContactSendDto contactSendDto)   
        {
            MailMessage mesaj = new MailMessage
            {
              From = new MailAddress(_smtpp.SenderMail),  // yazdığımız mailden asıl mail adresimize buradan mail gelir.
                To = { new MailAddress("ozdemiribrahim07@gmail.com")},
              Subject = contactSendDto.SubjectDesc, 
              IsBodyHtml = true,  // mailin güzel görünmesiin sağlar.
              Body = $"Gönderen : {contactSendDto.Name}, Mail Adresi : {contactSendDto.Mail} , Mesaj : {contactSendDto.Message}"

              // Body ile kullanıcı ismi maili ve mesajını görebiliriz.
               


            };

            SmtpClient smtpClient = new SmtpClient
            {
                EnableSsl = true,  // güvenlik
                Host =  _smtpp.Server,
                Port = _smtpp.Port,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpp.Username,_smtpp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network



            };

            smtpClient.Send(mesaj);

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, "Başarılı!");

        }





    }
}
