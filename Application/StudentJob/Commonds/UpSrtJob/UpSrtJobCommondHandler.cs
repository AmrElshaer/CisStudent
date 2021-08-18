using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentJob.Commonds.UpSrtJob
{
    public class UpSrtJobCommondHandler : IRequestHandler<UpSrtJobCommond, int>
    {
        private readonly ICisEngDbContext _cisEngDbContext;

        public UpSrtJobCommondHandler(ICisEngDbContext cisEngDbContext)
        {
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<int> Handle(UpSrtJobCommond request, CancellationToken cancellationToken)
        {
            Job job;
            if (request.Id.HasValue)
            {
                var entity =await _cisEngDbContext.Jobs.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                job = entity;
            }
            else {
                job = new Job();
                await _cisEngDbContext.Jobs.AddAsync(job);
            }
            job.Content = request.Content;
            job.Technology = request.Technology;
            job.Place = request.Place;
            job.ContactUs = request.ContactUs;
            job.CreateDate = DateTime.Now;
            job.CisStudentId = request.CisStudentId;
            await _cisEngDbContext.SaveChangesAsync(cancellationToken);
            return job.Id;
        }
    }
}
