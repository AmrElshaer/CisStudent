using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.StudentProfile.Command;
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
            private readonly IMediator _mediator;

            public UpSertFollowCommondHandler(ICisEngDbContext cisEngDbContext,IMediator mediator)
            {
                _cisEngDbContext = cisEngDbContext;
                _mediator = mediator;
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
                    // Send Email
                    var sendStudent =await _cisEngDbContext.CisStudents.FindAsync(request.CisStudentSendId);
                    var recieveStudent = await _cisEngDbContext.CisStudents.FindAsync(request.CisStudentRecieveId);
                    await _mediator.Publish(new StartFollow() { 
                         Message=new Notifications.Models.MessageDto()
                         {
                             Body=$"Hi {recieveStudent.Name},{sendStudent.Name} Start Follow you in CisEng",
                             To=$"amrelsher07@gmail.com",
                             Subject= $"Hi {recieveStudent.Name},{sendStudent.Name} Start Follow you in CisEng"
                         }
                    });
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
