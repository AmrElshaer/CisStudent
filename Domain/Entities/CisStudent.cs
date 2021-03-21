using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CisStudent
    {
        public CisStudent()
        {
            Posts = new HashSet<Post>();
            Jobs = new HashSet<Job>();
            SendFollow = new HashSet<Follow>();
            ReceiveFollow = new HashSet<Follow>();
            ApplyJobs = new HashSet<ApplyJob>();
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Follow> SendFollow { get; set; }
        public ICollection<Follow> ReceiveFollow { get; set; }
        public ICollection<ApplyJob> ApplyJobs { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<ApplyTraining> ApplyTrainings { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
