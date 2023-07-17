using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Repository;

namespace SWD392_PracinicalManagement.Service
{
    public class ExaminationFormService : IExaminationFormService
    {
        IExaminationFormRepository repo;

        public ExaminationFormService(IExaminationFormRepository repo)
        {
            this.repo = repo;
        }

        public List<ExaminationForm> GetExaminationFormByDate(DateTime MeetingDate)
        {
            return repo.GetExaminationFormByDate(MeetingDate);
        }

        public List<ExaminationForm> GetExaminationFormByDoctorId(int doctorCode)
        {
            return repo.GetExaminationFormByDoctorId(doctorCode);
        }

        public List<ExaminationForm> GetExaminationFormByPatientId(int patientId)
        {
            return repo.GetExaminationFormByPatientId(patientId);
        }

        public List<ExaminationForm> GetExaminationForms()
        {
            return repo.GetExaminationForms();
        }
    }
}
