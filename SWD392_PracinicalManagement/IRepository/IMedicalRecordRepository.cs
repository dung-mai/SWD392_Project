using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IRepository
{
    public interface IMedicalRecordRepository
    {
        List<MedicalRecord> GetPatientMedicalRecords(int pid);
    }
}
