using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class ExaminationResultRepository : IExaminationResultRepository
    {
        private SWD392_FinalProjectContext _context;

        public ExaminationResultRepository(SWD392_FinalProjectContext context)
        {
            _context = context;
        }

        public ExaminationResult? GetExaminationResultById(int resultId)
        {
            return _context.ExaminationResults
                .Include(e => e.Doctor)
                    .ThenInclude(d => d.Account)
                .Include(e => e.Service)
                .FirstOrDefault(r => r.ResultId == resultId);
        }
    }
}
