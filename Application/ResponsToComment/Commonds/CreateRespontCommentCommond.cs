using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ResponsToComment.Commonds
{
    public  class CreateRespontCommentCommond:IRequest<int>
    {
        public string Content { get; set; }
        public int? CommentId { get; set; }
        public int? CisStudentId { get; set; }
        public class CreateRespontCommentHander : IRequestHandler<CreateRespontCommentCommond, int>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public CreateRespontCommentHander(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<int> Handle(CreateRespontCommentCommond request, CancellationToken cancellationToken)
            {
                ResponseToComment reponseComment=new ResponseToComment();
                await _cisEngDbContext.ResponseToComments.AddAsync(reponseComment);
               reponseComment.CisStudentId = request.CisStudentId;
               reponseComment.CreateDate = DateTime.Now;
               reponseComment.Content = request.Content;
                reponseComment.CommentId = request.CommentId;
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return reponseComment.Id;
            }
        }
    }
}
