using FluentValidation;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.interfaces.Courses;

namespace SmartCertify.Application.DTOValidations
{
    public class UpdateCourseValidator : AbstractValidator<UpdateCourseDto>
    {
        public UpdateCourseValidator(ICourseRepository repository)
        {
            RuleFor(x => x.Title).NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MustAsync(async (title, cancellation) =>
                title == null || !await repository.IsTitleDuplicateAsync(title)
                )
                .WithMessage("The course title must be unique.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(500);
        }
    }
}
