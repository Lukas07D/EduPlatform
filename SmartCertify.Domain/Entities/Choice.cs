using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class Choice
{
    public int ChoiceId { get; set; }

    public int QuestionId { get; set; }

    public string ChoiceText { get; set; } = null!;

    public bool IsCode { get; set; }

    public bool IsCorrect { get; set; }

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    public virtual Question Question { get; set; } = null!;
}
