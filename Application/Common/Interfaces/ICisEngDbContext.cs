using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICisEngDbContext
    {
         DbSet<CisStudent> CisStudents { get; set; }
         DbSet<Job> Jobs { get; set; }
         DbSet<ApplyJob> ApplyJobs { get; set; }
         DbSet<Training> Trainings { get; set; }
         DbSet<ApplyTraining> ApplyTrainings { get; set; }
         DbSet<Post> Posts { get; set; }
         DbSet<Comment> Comments { get; set; }
         DbSet<Follow> Follows { get; set; }
         DbSet<Profile> Profiles { get; set; }
        DbSet<Like> Likes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
