using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GenTemplate.Application.Common.Interfaces;
using GenTemplate.Domain.Models;
using Newtonsoft.Json;

namespace GenTemplate.Infrastuscture.Service
{
    public class PostService : IPostService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PostService(IHttpClientFactory client)
        {
            _clientFactory = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var client = _clientFactory.CreateClient("jsonplaceholder");

            HttpResponseMessage responseApi = await client.GetAsync("/posts");

            // 401 509 404 -> 200 201 401 403 409

            responseApi.EnsureSuccessStatusCode();

            var content = await responseApi.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(content);

            return result;
        }
    }
}
