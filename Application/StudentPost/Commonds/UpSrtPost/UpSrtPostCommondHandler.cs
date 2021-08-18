using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentPost.Commonds.UpSrtPost
{
    public class UpSrtPostCommondHandler : IRequestHandler<UpSrtPostCommond, int>
    {
        private readonly ICisEngDbContext _cisEngDbContext;

        public UpSrtPostCommondHandler(ICisEngDbContext cisEngDbContext)
        {
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<int> Handle(UpSrtPostCommond request, CancellationToken cancellationToken)
        {
            Post post;
            if (request.Id.HasValue)
            {
                var entity =await _cisEngDbContext.Posts.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                post = entity;
            }
            else {
                post = new Post();
                await _cisEngDbContext.Posts.AddAsync(post);
            }
            post.Content = request.Content;
            post.Title = request.Title;
            post.CreateDate = DateTime.Now;
            post.CisStudentId = request.CisStudentId;
            await _cisEngDbContext.SaveChangesAsync(cancellationToken);
            return post.Id;
        }
    }
}
