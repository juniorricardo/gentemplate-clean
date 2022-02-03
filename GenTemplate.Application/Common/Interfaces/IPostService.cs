using System.Collections.Generic;
using System.Threading.Tasks;
using GenTemplate.Domain.Models;

namespace GenTemplate.Application.Common.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}