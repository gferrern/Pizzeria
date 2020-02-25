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
            using (FileStream fs = File.Open(path+"\\"+file.FileName+".jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                using(var ms = new MemoryStream()){
                file.FileData.CopyTo(ms);
                var filebytes = ms.ToArray();
                fs.Write(filebytes, 0, filebytes.Length);
                filebytes = null;
                }
            }
            Console.WriteLine("fichero guardado en {0}", path);
        }
    }
}