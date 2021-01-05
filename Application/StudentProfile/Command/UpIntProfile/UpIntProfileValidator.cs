using FluentValidation;


namespace Application.StudentProfile.Command.UpIntProfile
{
    public class UpIntProfileValidator:AbstractValidator<UpIntProfileCommond>
    {
        public UpIntProfileValidator()
        {
            RuleFor(p => p.CisStudentId).NotEmpty();
        }
    }
}
