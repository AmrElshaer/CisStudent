using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentLikes.Commonds
{
    public  class UpdateReactionCommond:IRequest<int>
    {
        public int PostId { get; set; }
        public int StudentId { get; set; }
        public int ReactionIndex { get; set; }
        public class UpdateReactionHandler : IRequestHandler<UpdateReactionCommond,int>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public UpdateReactionHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;

            }
            public async Task<int> Handle(UpdateReactionCommond request, CancellationToken cancellationToken)
            {
                var like= await _cisEngDbContext.Likes.FirstOrDefaultAsync(a=>a.PostId==request.PostId&&
                a.StudentId==request.StudentId);
                Like reacton ;
                if (like==null)
                {
                    reacton = new Like();
                    _cisEngDbContext.Likes.Add(reacton);
                }
                else
                {
                    reacton = like;
                }
                reacton. PostId = request.PostId;
                reacton.ReactionIndex = request.ReactionIndex;
                reacton.StudentId = request.StudentId ;
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return reacton.Id;
            }
        }
    }
}
