using System;
using System.Net.Http;
using System.Collections.Generic;
namespace pizzeria.Infraestructure{

    public interface IImageServerRepository
    {
        IEnumerable<String> GetRoutes(byte[] image);
    }
    public class ImageServerRepository:IImageServerRepository {
        private readonly IHttpClientFactory _client;
        public ImageServerRepository(IHttpClientFactory  client)
        {
            _client = client;
        }
        public IEnumerable<String> GetRoutes(byte[] image){
            return null;
        }
    }
}