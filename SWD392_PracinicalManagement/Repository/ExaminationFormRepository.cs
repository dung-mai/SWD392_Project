using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class ExaminationFormRepository : IExaminationFormRepository
    {
        SWD392_FinalProjectContext context = new SWD392_FinalProjectContext();
        public List<ExaminationForm> GetExaminationForms()
        {
            return context.ExaminationForms
                .Include(e => e.DoctorCodeNavigation.Account)
                .OrderByDescending(p => p.MeetingDate)
                .ToList();
        }
    }
}
