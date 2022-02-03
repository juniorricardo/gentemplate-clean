using System.Collections.Generic;
using MediatR;

namespace GenTemplate.Application.Features.Post.GetPost
{
    public abstract class GetPostContract
    {
        public class Query : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<PostResponse> Posts { get; set; }
            public string Message { get; set; }
            private Response(IEnumerable<PostResponse> posts) => Posts = posts;
            public static Response Create(IEnumerable<PostResponse> postResponses) => new Response(postResponses);
        }

        public class PostResponse
        {
            public int PostIdentify { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}
