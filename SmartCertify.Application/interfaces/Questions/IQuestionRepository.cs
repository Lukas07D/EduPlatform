using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.interfaces.Questions
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question?> GetQuestionsByIdAsync(int id);
        Task<Question> AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(Question question);
        Task UpdateQuestionAndChoicesAsync(int id, QuestionDto dto);
    }
}
