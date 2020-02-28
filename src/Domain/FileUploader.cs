using System;

namespace pizzeria.Domain
{
    public class FileUploader
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}