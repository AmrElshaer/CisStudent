using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentFollow.Commonds
{
    public class UpSertFollowCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAccepte { get; set; }
        public int? CisStudentSendId { get; set; }
        public int? CisStudentRecieveId { get; set; }
        public class UpSertFollowCommondHandler:IRequestHandler<UpSertFollowCommond,int>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public UpSertFollowCommondHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<int> Handle(UpSertFollowCommond request, CancellationToken cancellationToken)
            {
                Follow follow;
                if (request.Id.HasValue)
                {
                    var entity = await _cisEngDbContext.Follows.FindAsync(request.Id);
                    if (entity == null)
                        throw new NotFoundException(nameof(Follow), request.Id);
                    follow = entity;
                }
                else
                {
                    follow = new Follow();
                    await _cisEngDbContext.Follows.AddAsync(follow);
                }
                follow.CisStudentSendId = request.CisStudentSendId;
                follow.CisStudentRecieveId = request.CisStudentRecieveId;
                follow.CreateDate = DateTime.Now;
                follow.IsAccepte = request.IsAccepte;
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return follow.Id;
            }
        }
    }
}
