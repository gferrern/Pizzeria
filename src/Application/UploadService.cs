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
                using(var ms = new MemoryStream()){
                fileupload.FileData.CopyTo(ms);
                var filebytes = ms.ToArray();
                fs.Write(filebytes, 0, filebytes.Length);
                filebytes = null;
                }
            }
            Console.WriteLine("fichero guardado en {0}", path);
        }
    }
}