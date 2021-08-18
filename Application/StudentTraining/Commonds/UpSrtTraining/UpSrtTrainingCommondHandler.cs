using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentTraining.Commonds.UpSrtTraining
{
    public class UpSrtTrainingCommondHandler : IRequestHandler<UpSrtTrainingCommond, int>
    {
        private readonly ICisEngDbContext _cisEngDbContext;

        public UpSrtTrainingCommondHandler(ICisEngDbContext cisEngDbContext)
        {
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<int> Handle(UpSrtTrainingCommond request, CancellationToken cancellationToken)
        {
            Training training;
            if (request.Id.HasValue)
            {
                var entity =await _cisEngDbContext.Trainings.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                training = entity;
            }
            else {
                training = new Training();
                await _cisEngDbContext.Trainings.AddAsync(training);
            }
            training.Content = request.Content;
            training.Technology = request.Technology;
            training.Place = request.Place;
            training.CreateDate = DateTime.Now.ToString();
            training.CisStudentId = request.CisStudentId;
            training.ContactUs = request.ContactUs;
            await _cisEngDbContext.SaveChangesAsync(cancellationToken);
            return training.Id;
        }
    }
}
