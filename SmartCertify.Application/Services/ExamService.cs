using AutoMapper;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.interfaces.Certifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamService _service;
        private readonly IMapper _mapper;
        public ExamService(IExamService service, IMapper mapper) 
        {
        _service = service; 
        _mapper = mapper;
        }
        public Task<ExamResponseDto> GetExamDetailsAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamDto?> GetExamMetaData(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserExamQuestionsDto>> GetExamQuestionsAsync(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserExam>> GetUserExamsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveExamStatus(ExamFeedbackDto examFeedback)
        {
            throw new NotImplementedException();
        }

        public Task<ExamDto> StartExamAsync(int courseId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserChoiceAsync(int id, UpdateUserQuestionChoiceDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
