using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }
        public List<MedicalRecord> GetPatientMedicalRecords(int pid)
        {
           return _medicalRecordRepository.GetPatientMedicalRecords(pid);
        }
    }
}
