using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class Question
{
    public int QuestionId { get; set; }

    public int CourseId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string DifficultyLevel { get; set; } = null!;

    public bool IsCode { get; set; }

    public bool HasMultipleAnswers { get; set; }

    public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
}
