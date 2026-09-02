using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.interfaces.Questions
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
        Task<QuestionDto?> GetQuestionsByIdAsync(int id);
        Task AddQuestionAsync(CreateQuestionDto dto);
        Task UpdateQuestionAsync(int id, UpdateQuestionDto dto);
        Task DeleteQuestionAsync(int id);
        Task UpdateQuestionAndChoicesAsync(int id, QuestionDto dto);
        Task<QuestionDto> AddQuestionAndChoicesAsync(QuestionDto dto);
    }
}

            