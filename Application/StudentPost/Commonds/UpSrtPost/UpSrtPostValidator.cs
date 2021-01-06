using FluentValidation;
namespace Application.StudentPost.Commonds.UpSrtPost
{
    public class UpSrtPostValidator:AbstractValidator<UpSrtPostCommond>
    {
        public UpSrtPostValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.CisStudentId).NotEmpty();
        }
    }
}
