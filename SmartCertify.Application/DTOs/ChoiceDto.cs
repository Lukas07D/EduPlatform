using SmartCertify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Application.DTOs
{
    
}


public class ChoiceDto 
        {
        public int ChoiceId { get; private set; }
        public int QuestionId { get; private set; }
        public string QuestionText { get; private set;} = string.Empty;
        public bool IsCorrect { get; private set; }
        

        }
    public class CreateChoiceDto 
        {
    [Required]
       // id pytania 
       public int QuestionId { get; set; }
    // tekst pytania
    [Required]
    [StringLength(200, ErrorMessage = "Choice text cannot exceed 200 characters.")]
       public string ChoiceText { get; set; } = string.Empty;
       // zaznaczenie pytania 
       public bool IsCode { get; set; }
       // prawda albo fałsz 
       public bool IsCorrect { get; set; }

        }
public class UpdateUserChoice 
{
     public int ChoiceId { get; set; }
     public bool IsCorrect { get; set; }
 
} 
    public class UpdateChoiceDto : UpdateUserChoice 
       {
    [Required]
    [StringLength(200, ErrorMessage ="Choice text cannot exceed 20 characters.")]
    public string ChoiceText { get; set; } = string.Empty;
    public bool IsCode { get; set; }
       }

