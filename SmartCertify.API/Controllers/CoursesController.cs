using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.interfaces.Courses;
using SmartCertify.Application.DTOValidations;

namespace SmartCertify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IValidator<CreateCourseDto> validator;
        private readonly IValidator<UpdateCourseDto> updateValidator;
        public CoursesController(ICourseService service, IValidator<CreateCourseDto> validator, IValidator<UpdateCourseDto> updateValidator) 
        {
           this._service = service;
           this.validator = validator;
           this.updateValidator = updateValidator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllCoursesAsync() 
        {
            var courses = await _service.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        
        public async Task<ActionResult> GetCourse(int id)
        {
            var course = await _service.GetCourseByIdAsync(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCourseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto createCourseDto) 
        {
            var validationResult = await validator.ValidateAsync(createCourseDto);

            if (!validationResult.IsValid) 
            {
                return BadRequest(validationResult.Errors);
            }

            await _service.AddCourseAsync(createCourseDto);
            return CreatedAtAction(nameof(GetCourse), new { id = createCourseDto.Title }, createCourseDto);
        }

        /// <summary>
        /// Updates an existing course.    
        /// </summary>
        /// <param name="id">The ID of the course to update.</param>
        /// <param name="updateCourseDto">The updated course details.</param>
        /// <response code="204">Indicates the update was successful.</response>
        /// <response code="400">If the input is invalid.</response>


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto) 
        {
            var validationResult = await updateValidator.ValidateAsync(updateCourseDto);
            if (!validationResult.IsValid) 
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.UpdateCourseAsync(id, updateCourseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse(int id) 
        {
        await _service.DeleteCourseAsync(id);
        return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateDescription([FromRoute] int id, [FromBody] CourseUpdateDescriptionDto model) 
        {
            await _service.UpdateDescriptionAsync(id, model.Description);
            return NoContent();
        }
    }
}
