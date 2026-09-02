using FluentValidation;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.DTOValidations
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        private readonly ICourseRepository courseRepository;
        public CreateCourseValidator(ICourseRepository courseRepository) 
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(100)
                .MustAsync(async (title, cancellation) => !await courseRepository.IsTitleDuplicateAsync(title))
                .WithMessage("The course title must be a unique.");
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(500);
                this.courseRepository = courseRepository;
        }
    }
}
