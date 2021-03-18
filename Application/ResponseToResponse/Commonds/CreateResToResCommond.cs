using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ResToResModel = Domain.Entities.ResponseToResponse;
namespace Application.ResponseToResponse.Commonds
{
    public  class CreateResToResCommond:IRequest<int>
    {
        public string Content { get; set; }
        public int? ResToCommId { get; set; }
        public int? CisStudentId { get; set; }
        public class CreateResToResCommondHandler : IRequestHandler<CreateResToResCommond, int>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public CreateResToResCommondHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<int> Handle(CreateResToResCommond request, CancellationToken cancellationToken)
            {
                ResToResModel responseTores = new ResToResModel();
                await _cisEngDbContext.ResponseToResponses.AddAsync(responseTores);
                responseTores.CisStudentId = request.CisStudentId;
                responseTores.CreateDate = DateTime.Now;
                responseTores.Content = request.Content;
                responseTores.ResponseToCommentId = request.ResToCommId;
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return responseTores.Id;
            }
        }
    }
}
