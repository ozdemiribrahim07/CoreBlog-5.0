using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Utilitie.Sonuc.Concrete
{
    public class DataSonuc<T> : IDataSonuc<T>
    {

        public DataSonuc(SonucStatus sonucStatus, T data)
        {
            SonucStatus = sonucStatus;
            Data = data;
        }

        public DataSonuc(SonucStatus sonucStatus, string message, T data)
        {
            SonucStatus = sonucStatus;
            Message = message;
            Data = data;
        }
        public DataSonuc(SonucStatus sonucStatus, string message, T data, Exception exception)
        {
            SonucStatus = sonucStatus;
            Message = message;
            Exception = exception;
            Data = data;
        }


        public T Data {get;}

        public SonucStatus SonucStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
