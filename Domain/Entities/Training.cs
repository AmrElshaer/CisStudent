using System.Collections.Generic;
namespace Domain.Entities
{
    public class Training
    {
        public Training()
        {
            Applies = new HashSet<ApplyTraining>();
        }
        public int Id { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public string CreateDate { get; set; }
        public string Content { get; set; }
        public CisStudent CisStudent { get; set; }
        public ICollection<ApplyTraining> Applies { get; set; }
    }
}
