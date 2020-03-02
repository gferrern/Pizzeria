using System;
namespace pizzeria.Domain{
    public class TempImage{
        public Guid Id { get; set; } 
        public byte[] Image {get;set;}
        public static TempImage Create(byte[] Image){
            return new TempImage(){
                Id=Guid.NewGuid(),
                Image = Image,
            };
        }
    }
}