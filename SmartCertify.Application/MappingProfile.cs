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
         
         CreateMap<CreateQuestionDto, Question>();
         CreateMap<UpdateQuestionDto, Question>();

         // ChoiceDto exposes the choice text as QuestionText, so map it explicitly in both directions
         CreateMap<Choice, ChoiceDto>()
            .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.ChoiceText))
            .ReverseMap()
            .ForMember(dest => dest.ChoiceText, opt => opt.MapFrom(src => src.QuestionText));
         CreateMap<CreateChoiceDto, Choice>();
         // Never overwrite the primary key of a tracked entity from request data
         CreateMap<UpdateUserChoice, Choice>()
            .ForMember(dest => dest.ChoiceId, opt => opt.Ignore());
         CreateMap<UpdateChoiceDto, Choice>()
            .ForMember(dest => dest.ChoiceId, opt => opt.Ignore());

          CreateMap<Question, QuestionDto>()
         .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices));

          CreateMap<QuestionDto, Question>()
         .ForMember(dest => dest.Choices, opt => opt.Ignore()); // Ignore to handle manually

         CreateMap<Exam, ExamDto>().ReverseMap();

        }
    }
}
