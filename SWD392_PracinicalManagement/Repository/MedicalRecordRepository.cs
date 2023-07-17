using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private SWD392_FinalProjectContext _context;

        public MedicalRecordRepository(SWD392_FinalProjectContext context)
        {
            _context = context;
        }

        public List<MedicalRecord> GetPatientMedicalRecords(int pid)
        {
             return _context.MedicalRecords
                .Include(acc => acc.Patient)
                .Where(acc => acc.PatientId == pid).ToList();
        }
    }
}
