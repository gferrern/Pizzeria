using System;

namespace pizzeria.Dtos{
    public class fileUpload{
        public string FileName {get;set;}
        
        public byte[] FileData { get; set; }
    }
}
