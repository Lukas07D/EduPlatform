using System;
using System.Collections.Generic;

namespace SmartCertify.Domain.Entities;

public partial class Exam
{
    public int ExamId { get; set; }

    public int CourseId { get; set; }

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime StartedOn { get; set; }

    public DateTime? FinishedOn { get; set; }

    public string? Feedback { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    public virtual UserProfile User { get; set; } = null!;
}
