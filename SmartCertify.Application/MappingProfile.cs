using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SmartCertify.Application.DTOs;
using SmartCertify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartCertify.Application
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        {
         CreateMap<Course, CourseDto>().ReverseMap();
         CreateMap<CreateCourseDto, Course>();
         CreateMap<UpdateCourseDto, Course>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
         
         CreateMap<QuestionDto, Question>().ReverseMap();
         CreateMap<CreateQuestionDto, Question>();
         CreateMap<UpdateQuestionDto, Question>();

            CreateMap<Choice, ChoiceDto>().ReverseMap()
               .ForMember(dest => dest.ChoiceText, opt => opt.MapFrom(src => src.QuestionText));
         CreateMap<CreateChoiceDto, Choice>();
         CreateMap<UpdateChoiceDto, Choice>();

          CreateMap<Question, QuestionDto>()
         .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));

          CreateMap<QuestionDto, Question>()
         .ForMember(dest => dest.Choices, opt => opt.Ignore()); // Ignore to handle manually

         CreateMap<ExamDto, Exam>();
         CreateMap<Exam, ExamDto>().ReverseMap();

        }
    }
}
