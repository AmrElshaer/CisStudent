using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.StudentProfile.Queries.GetProfileById;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentProfile.Queries.SearchProfile
{
    public class SearchQuery:IRequest<IEnumerable<ProfileDto>>
    {
        public string Text { get; set; }
        public class SearchQueryHandler : IRequestHandler<SearchQuery, IEnumerable<ProfileDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public SearchQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;

            }
            public async Task<IEnumerable<ProfileDto>> Handle(SearchQuery request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Text))
                {
                    throw new NotFoundException("Search",request.Text);
                }
                var searchValue = request.Text.ToLowerInvariant();
                var profiles=await  _cisEngDbContext.Profiles.Include(a => a.CisStudent).Where(a =>
                  a.CisStudent.Name.ToLowerInvariant().Contains(searchValue) ||
                  a.City.ToLowerInvariant().Contains(searchValue) ||
                  a.University.ToLowerInvariant().Contains(searchValue) ||
                  a.Programing_Language.ToLowerInvariant().Contains(searchValue)).
                  ProjectTo<ProfileDto>(_mapper.ConfigurationProvider).ToListAsync();
                return profiles;
            }
        }
    }
}
