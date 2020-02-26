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

        public void Upload(FileUploader fileupload)
        {
            Directory.CreateDirectory("tmp");
            string path = Path.GetFullPath("tmp");
            using (FileStream fs = File.Open(path+"\\"+fileupload.FileName+".jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                fs.Write(fileupload.FileData, 0, fileupload.FileData.Length);
            }
            Console.WriteLine("fichero guardado en {0}", path);
        }
    }
}