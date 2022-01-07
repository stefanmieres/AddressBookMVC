using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookMVC.Services.Interfaces
{
    public class BasicImageService : IImageService

    {
        string IImageService.ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            if (fileData is null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(fileData);
            return $"data: {extension};base64,{imageBase64Data}";
        }

        async Task<byte[]> IImageService.ConvertFileToByteArrayAsync(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();
            return byteFile;
        }
    }
}
