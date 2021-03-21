using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Comments.Commonds
{
    public  class CreateCommentCommond:IRequest<int>
    {
        public string Content { get; set; }
        public int? PostId { get; set; }
        public int? CisStudentId { get; set; }
        public int? CommentId { get; set; }
        public class CreateCommentHander : IRequestHandler<CreateCommentCommond, int>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public CreateCommentHander(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<int> Handle(CreateCommentCommond request, CancellationToken cancellationToken)
            {
                Comment comment=new Comment();
                await _cisEngDbContext.Comments.AddAsync(comment);
                comment.CisStudentId = request.CisStudentId;
                comment.CreateDate = DateTime.Now;
                comment.Content = request.Content;
                comment.PostId = request.PostId;
                comment.CommentId = request.CommentId;
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return comment.Id;
            }
        }
    }
}
