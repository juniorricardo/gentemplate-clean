using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GenTemplate.Application.Common.Interfaces;
using MediatR;

namespace GenTemplate.Application.Features.Post.GetPost
{
    public class Handler : IRequestHandler<GetPostContract.Query, GetPostContract.Response>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public Handler(IPostService postService, IMapper mapper)
        {
            _postService = postService ?? throw new System.ArgumentNullException(nameof(postService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<GetPostContract.Response> Handle(GetPostContract.Query request, 
                                                     CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Models.Post> responseService = await _postService.GetPosts();

            var collection = _mapper.Map<IEnumerable<GetPostContract.PostResponse>>(responseService);

            return GetPostContract.Response.Create(collection);
        }
    }
}
