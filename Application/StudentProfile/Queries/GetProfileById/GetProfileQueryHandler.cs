using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using StdProfile = Domain.Entities.Profile;
namespace Application.StudentProfile.Queries.GetProfileById
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery,ProfileDto>
    {
        private readonly ICisEngDbContext _cisEngDbContext;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(ICisEngDbContext cisEngDbContext,IMapper mapper)
        {
            _cisEngDbContext = cisEngDbContext;
            _mapper = mapper;
        }
        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var profile =await _cisEngDbContext.Profiles.Include(p=>p.CisStudent).FirstOrDefaultAsync(p=>p.CisStudentId==request.StudentId);
            if (profile==null)
            {
                 throw new NotFoundException(nameof(StdProfile), request.StudentId);
            }
            return _mapper.Map<ProfileDto>(profile);

        }
    }
}
