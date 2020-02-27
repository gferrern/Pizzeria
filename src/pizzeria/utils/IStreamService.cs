using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;

    public interface IStreamService
    {
        Task<byte[]> GetPic(IFormFile file);
    }