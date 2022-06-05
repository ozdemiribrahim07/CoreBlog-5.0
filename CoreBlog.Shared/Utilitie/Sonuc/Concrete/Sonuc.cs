using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Utilitie.Sonuc.Concrete
{
    public class Sonuc : ISonuc
    {
        public Sonuc(SonucStatus sonucStatus)
        {
            SonucStatus = sonucStatus;
        }

        public Sonuc(SonucStatus sonucStatus , string message)
        {
            SonucStatus = sonucStatus;
            Message = message;
        }

        public Sonuc(SonucStatus sonucStatus, string message ,Exception exception)
        {
            SonucStatus = sonucStatus;
            Message = message;
            Exception = exception;
        }

        public SonucStatus SonucStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
