using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class ExamQuestion
{
    public int ExamQuestionId { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public int? SelectedChoiceId { get; set; }

    public bool? IsCorrect { get; set; }

    public bool? ReviewLater { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual Choice? SelectedChoice { get; set; }
}
