using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCertify.Domain.Entities;
using SmartCertify.Application.DTOs;
namespace SmartCertify.Application.interfaces.Certifications
{
    public interface IExamRepository
    {
  
        Task<List<Question>> GetRandomQuestionsAsync(int courseId, int count);
        Task CreateExamWithQuestionsAsync(Exam exam, List<Question> questions);
        Task UpdateExamQuestionAsync(ExamQuestion examQuestion);
        Task<ExamQuestion?> GetExamQuestionAsync(int examId, int examQuestionId);
        Task<List<ExamQuestion>> GetExamQuestionsAsync(int examId);
        Task<List<UserExam>> GetUserExamsAsync(int userId);
        Task<ExamDto?> GetExamMetaDataAsync(int examId);
        Task SaveExamStatusAsync(int examId, string feedback);

        Task<ExamResponseDto> GetExamDetailsAsync(int examId);

    }
}
