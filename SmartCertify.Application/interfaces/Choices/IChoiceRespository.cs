using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCertify.Domain.Entities;

namespace SmartCertify.Application.interfaces.Choices
{
    public interface IChoiceRespository
    {
        Task<IEnumerable<Choice>> GetAllChoicesAsync(int questionId);
        Task<Choice?> GetChoiceByIdAsync(int id);
        Task AddChoiceAsync(Choice choice);
        Task UpdateChoiceAsync(Choice choice);
        Task DeleteChoiceAsync(Choice choice);
    }
}
