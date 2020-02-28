using pizzeria.Domain;
using pizzeria.Infraestructure;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Application
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _repositoryUpload;
        public UploadService(IUploadRepository repositoryUpload)
        {
            _repositoryUpload = repositoryUpload;
        }

        public void Upload(FileUploader fileupload)
        {
            Directory.CreateDirectory("tmp");
            string path = Path.GetFullPath("tmp");
            using (FileStream fs = File.Open(path + "\\" + fileupload.FileName + ".jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                fs.Write(fileupload.FileData, 0, fileupload.FileData.Length);
            }
            Console.WriteLine("fichero guardado en {0}", path);
        }
        public void Upload2(IFormFile file)
        {
            Directory.CreateDirectory("tmp");
            string path = Path.GetFullPath("tmp");

            Console.WriteLine("fichero guardado en {0}", path);
        }
    }
}