using FluentValidation;
namespace Application.StudentJob.Commonds.UpSrtJob
{
    public class UpSrtJobValidator:AbstractValidator<UpSrtJobCommond>
    {
        public UpSrtJobValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.CisStudentId).NotEmpty();
        }
    }
}
