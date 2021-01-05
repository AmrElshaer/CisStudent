using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentProfile.Command.UpIntProfile
{
    public class UpIntProfileHandler : IRequestHandler<UpIntProfileCommond,int>
    {
        private readonly ICisEngDbContext _cisEngDbContext;

        public UpIntProfileHandler(ICisEngDbContext cisEngDbContext)
        {
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<int> Handle(UpIntProfileCommond request, CancellationToken cancellationToken)
        {
            Profile profile;
            if (request.Id.HasValue)
            {
                profile = await _cisEngDbContext.Profiles.FindAsync(request.Id.Value);
            }
            else
            {
                profile = new Profile();
                await _cisEngDbContext.Profiles.AddAsync(profile);
               
            }
            profile.kind = request.kind;
            profile.Colleage = request.Colleage;
            profile.University = request.University;
            profile.Experience = request.Experience;
            profile.Age = request.Age;
            profile.Carear = request.Carear;
            profile.Appreciation = request.Appreciation;
            profile.Company = request.Company;
            profile.Addition = request.Addition;
            profile.Programing_Language = request.Programing_Language;
            profile.Language = request.Language;
            profile.CisStudentId = request.CisStudentId;
            profile.City = request.City;
            await _cisEngDbContext.SaveChangesAsync(cancellationToken);
            return profile.Id;
        }
    }
}
