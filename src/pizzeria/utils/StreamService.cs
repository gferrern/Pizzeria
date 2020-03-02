using Microsoft.AspNetCore.Http;
using System.IO;
namespace pizzeria.utils
{
    public class StreamService : IStreamService
    {
        public byte[] GetBytes(IFormFile file)
        {
            byte[] filebytes;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                filebytes = memoryStream.ToArray();
            }
            return filebytes;
        }
    }
}
