using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCertify.Domain.Entities;

namespace SmartCertify.Application.interfaces.Courses
{
    public interface ICourseRepository
    {
      //  IEnumerable<Course> GetAllCourses(); //wersja synchroniczna - blokuje watki
        Task<List<Course>> GetAllCoursesAsync();  // wersja asynchroniczna - nie blokuje wątkow, zwraca obietnice a po await kolekcje
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task<bool> IsTitleDuplicateAsync(string title);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task UpdateDescriptionAsync(int courseId, string description);


        
    }
}
