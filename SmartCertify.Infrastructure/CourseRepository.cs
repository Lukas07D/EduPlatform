using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartCertify.Application.interfaces.Courses;
using SmartCertify.Domain.Entities;
using SmartCertify.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SmartCertifyDbContext _dbContext;
        public CourseRepository(SmartCertifyDbContext dbContext) 
        {
        this._dbContext = dbContext;
        }

        public async Task AddCourseAsync(Course course)
        {
        _dbContext.Courses.Add(course);
        await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Course course)
        {
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }

        public  Task<List<Course>> GetAllCoursesAsync()
        {
             return  _dbContext.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            return await _dbContext.Courses.FindAsync(courseId);
        }

        public async Task<bool> IsTitleDuplicateAsync(string title)
        {
            return await _dbContext.Courses.AnyAsync(c => c.Title == title);
            
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDescriptionAsync(int courseId, string description)
        {
            var course = await _dbContext.Courses.FindAsync(courseId);
            if (course == null) throw new KeyNotFoundException("Course not found.");

            course.Description = description;
            await _dbContext.SaveChangesAsync();
        }

        /*
         * Key Concepts:
         * async:
         * 
         Marks a method as asynchronius:
        Allows the use of the await keyword inside the method.
        Must return a Task , Task<T>, or void (for event handlers).
        await:

          Waits for an asynchronius task to complete.
        Pauses the execution of the method until the awaited task finishes without blocking the thread.
         */

    }
}
