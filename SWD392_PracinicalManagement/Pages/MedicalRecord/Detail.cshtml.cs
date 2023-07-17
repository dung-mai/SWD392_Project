using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.DataAccess.Models;

namespace SWD392_PracinicalManagement.Pages.MedicalRecord
{
    public class Detail : PageModel
    {

        public DataAccess.Models.MedicalRecord? Md;
        public string ErrorMessage = "";
        private SWD392_FinalProjectContext _context;
        public Detail(SWD392_FinalProjectContext context)
        {
            _context = context;
        }
        public void OnGet(int medicalRecordId)
        {
            Md = _context.MedicalRecords
                .Include(p => p.ExaminationResults)
                .FirstOrDefault(p => p.MedicalRecordId == medicalRecordId);
            if (Md == null)
            {
                ErrorMessage = "Cannot found!";
            }
        }
    }   
}