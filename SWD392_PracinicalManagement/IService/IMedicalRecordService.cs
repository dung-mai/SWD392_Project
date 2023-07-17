using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IService
{
    public interface IMedicalRecordService
    {
        List<MedicalRecord> GetPatientMedicalRecords(int pid);

    }
}
