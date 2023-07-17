using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class ExaminationFormRepository : IExaminationFormRepository
    {
        SWD392_FinalProjectContext context = new SWD392_FinalProjectContext();

        public List<ExaminationForm> GetExaminationFormByDate(DateTime MeetingDate)
        {
            return context.ExaminationForms
                .Where(e => e.MeetingDate.Value.Date == MeetingDate.Date)
                .Include(e => e.DoctorCodeNavigation.Account)
                .Include(e => e.Patient)
                .OrderByDescending(p => p.MeetingDate)
                .ToList();
        }

        public List<ExaminationForm> GetExaminationFormByDoctorId(int doctorCode)
        {
            return context.ExaminationForms
                .Where(e => e.DoctorCode == doctorCode)
                .Include(e => e.DoctorCodeNavigation.Account)
                .Include(e => e.Patient)
                .OrderByDescending(p => p.MeetingDate)
                .ToList();
        }

        public List<ExaminationForm> GetExaminationFormByPatientId(int patientId)
        {
            return context.ExaminationForms
                .Where(e => e.PatientId == patientId)
                .Include(e => e.DoctorCodeNavigation.Account)
                .Include(e => e.Patient)
                .OrderByDescending(p => p.MeetingDate)
                .ToList();
        }

        public List<ExaminationForm> GetExaminationForms()
        {
            return context.ExaminationForms
                .Include(e => e.DoctorCodeNavigation.Account)
                .Include(e => e.Patient)
                .OrderByDescending(p => p.MeetingDate)
                .ToList();
        }
    }
}
