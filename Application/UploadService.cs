using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;
using System;
using System.IO;
using System.Collections;
using System.Text;

namespace pizzeria.Application
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _repositoryUpload;
        public UploadService(IUploadRepository repositoryUpload)
        {
            _repositoryUpload = repositoryUpload;
        }

        public void Upload(fileUpload fileupload)
        {
            Directory.CreateDirectory("tmp");
            string path = Path.GetFullPath("tmp");

            var file = FileUploader.prepareUpload(fileupload);
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }
            Console.WriteLine("fichero guardado en {0}", path);
        }
    }
}