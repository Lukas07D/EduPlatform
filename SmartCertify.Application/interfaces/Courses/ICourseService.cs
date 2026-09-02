using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.interfaces.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto?> GetCourseByIdAsync(int courseId);
        Task<bool> IsTitleDuplicateAsync(string title);
        Task AddCourseAsync(CreateCourseDto createCourseDto);
        Task UpdateCourseAsync(int courseId, UpdateCourseDto updateCourseDto);
        Task DeleteCourseAsync(int courseId);
        Task UpdateDescriptionAsync(int courseeId, string description);
    }
}
