using Microsoft.EntityFrameworkCore;
using SmartCertify.Application.interfaces.Choices;
using SmartCertify.Domain.Entities;
using SmartCertify.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCertify.Infrastructure
{
    public class ChoiceRespository : IChoiceRespository
    {
        private readonly SmartCertifyDbContext _context;

        public ChoiceRespository(SmartCertifyDbContext context) 
        {
        _context = context;
        }
        public async Task AddChoiceAsync(Choice choice)
        {
            await _context.AddAsync(choice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChoiceAsync(Choice choice)
        {
            await _context.Choices.AddAsync(choice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Choice>> GetAllChoicesAsync(int questionId)
        {
            return await _context.Choices.Where(c => c.QuestionId == questionId).ToListAsync();
        }

        public async Task<Choice?> GetChoiceByIdAsync(int id)
        {
            return await _context.Choices.FirstOrDefaultAsync(c => c.ChoiceId == id);
        }

        public async Task UpdateChoiceAsync(Choice choice)
        {
            _context.Choices.Update(choice);
            await _context.SaveChangesAsync();
        }
    }
}
