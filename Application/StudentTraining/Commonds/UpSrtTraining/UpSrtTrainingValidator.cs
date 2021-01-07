using FluentValidation;
namespace Application.StudentTraining.Commonds.UpSrtTraining
{
    public class UpSrtTrainingValidator:AbstractValidator<UpSrtTrainingCommond>
    {
        public UpSrtTrainingValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.CisStudentId).NotEmpty();
        }
    }
}
