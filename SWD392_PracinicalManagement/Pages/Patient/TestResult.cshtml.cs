using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Extensions;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Util;
using System.Web;

namespace SWD392_PracinicalManagement.Pages.Patient
{
    public class TestResultModel : PageModelBase
    {
        //medical id + date+type servise
        SWD392_FinalProjectContext _context;
        //List<MedicalRecord> _medicalRecords;
        public Models.MedicalRecord _medicalRecords;

        public List<Models.ExaminationResult> listResult;
        public List<string> tests { get; set; }
        public DateTime examAt { get; set; }
        public string testName;
        public TestResultModel(SWD392_FinalProjectContext sWD392_FinalProjectContext)
        {
            authorizedRoles = new string[] { Constant.PATIENT_ROLE };
            _context = sWD392_FinalProjectContext;
        }
        public async Task<IActionResult> OnGetAsync(string? id, string? name)
        {
            Account? account = HttpContext.Session.Get<Account>("loggedInAccount");

            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            //get medical record id
            _medicalRecords = _context.MedicalRecords.FirstOrDefault(p => p.PatientId.Equals(account.AccountId));
            int mdcId = _medicalRecords.MedicalRecordId;

            if (mdcId != 0)
            {
                int servId = 0;
                testName = id;
                // Handle the case where no medical record is found for the patient
                examAt = DateTime.Parse(HttpUtility.UrlDecode(name));
                tests = new List<string>();
                PracinicalCategory servecate = _context.PracinicalCategories.FirstOrDefault(p => p.PracinicalCategoryName.Equals(id));
                if (servecate != null)
                {
                    servId = servecate.PracinicalCategoryId;
                }
                listResult = _context.ExaminationResults.Where(p => p.CreatedAt == examAt && p.MedicalRecord == mdcId && p.ServiceId== servId).ToList();
                
            }
            return Page();
        }
    }
}
