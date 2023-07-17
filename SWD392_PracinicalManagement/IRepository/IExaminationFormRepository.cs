using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IRepository
{
    public interface IExaminationFormRepository
    {
        List<ExaminationForm> GetExaminationForms();
        public List<ExaminationForm> GetExaminationFormByDate(DateTime MeetingDate);
        public List<ExaminationForm> GetExaminationFormByDoctorId(int doctorCode);
        public List<ExaminationForm> GetExaminationFormByPatientId(int patientId);
    }
}
