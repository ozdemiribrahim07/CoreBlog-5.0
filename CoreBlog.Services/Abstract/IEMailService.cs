using CoreBlog.Entities.Dtos;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Abstract
{
    public interface IEMailService
    {
        ISonuc Gonder(ContactSendDto contactSendDto);
        ISonuc GonderMail(ContactSendDto contactSendDto);



    }
}
