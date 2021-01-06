﻿using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentPost.Queries
{
    public class GetPostQuery : IRequest<PostDto>
    {
        public int Id { get; set; }
        public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDto>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetPostQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Posts.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Post), request.Id);
                }
                var postDto = _mapper.Map<PostDto>(entity);
                return postDto;
            }
        }
    }
}
