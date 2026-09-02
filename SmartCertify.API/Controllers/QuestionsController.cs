using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using SmartCertify.Application.DTOs;
using SmartCertify.Application.interfaces.Courses;
using SmartCertify.Application.DTOValidations;
using SmartCertify.Application.interfaces.Questions;
using System.Reflection.Metadata.Ecma335;

namespace SmartCertify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            return Ok(await _service.GetAllQuestionsAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestionById(int id)
        {
            var question = await _service.GetQuestionsByIdAsync(id);
            return question == null ? NotFound() : Ok(question);

        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
        {
            await _service.AddQuestionAsync(dto);
            return CreatedAtAction(nameof(GetQuestions), new { id = dto.CourseId }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionDto dto) {
            await _service.UpdateQuestionAsync(id, dto);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id) 
        {
        await _service.DeleteQuestionAsync(id);
        return NoContent();
        }

        [HttpPost("CreateQuestionChoices")]
        public async Task<IActionResult> CreateQuestionChoices([FromBody]  QuestionDto dto)
        {
            //nie mozna przypisac void do zmiennej o type okreslonym niejawnie
            var createdResource = await _service.AddQuestionAndChoicesAsync(dto);

            return CreatedAtAction(nameof(GetQuestions), new { id = createdResource.QuestionId }, createdResource);
            
        }


    


    }

    }
