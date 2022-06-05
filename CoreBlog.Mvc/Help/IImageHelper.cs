using CoreBlog.Entities.Dtos;
using CoreBlog.Entities.enumtypes;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Help
{
    public interface IImageHelper
    {
        Task<IDataSonuc<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataSonuc<ImageDeletedDto> Delete(string pictureName);

    }
}
