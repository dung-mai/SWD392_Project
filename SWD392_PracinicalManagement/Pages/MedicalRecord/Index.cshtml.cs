using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Pages.MedicalRecord
{
    public class Index : PageModel
    {
        private SWD392_FinalProjectContext _context;
        public List<Models.MedicalRecord> MedicalRecords;
        public string ErrorMessage = "";

        public Index(SWD392_FinalProjectContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            MedicalRecords = _context.MedicalRecords.ToList();
        }

        public void OnGetSearch(string text)
        {
            Models.MedicalRecord mr = _context.MedicalRecords
                .Include(p => p.Patient)
                .FirstOrDefault(p => p.Patient.Name.Contains(text) || p.MedicalRecordId.ToString().Contains(text));
            MedicalRecords.Clear();
            if (mr == null)
            {
                ErrorMessage = "Not Found!";
            }
            else
            {
                MedicalRecords.Add(mr);
            }
        }
    }
}