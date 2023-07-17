using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.Extensions;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Util;
using System.Web;

namespace SWD392_PracinicalManagement.Pages.Patient
{
    public class ExaminationDetailModel : PageModelBase
    {

        SWD392_FinalProjectContext _context;
        //List<MedicalRecord> _medicalRecords;
        public Models.MedicalRecord _medicalRecords;

        public List<Models.ExaminationResult> listResult;
        public List<string> tests { get; set; }
        public DateTime examAt { get; set; }
        public ExaminationDetailModel(SWD392_FinalProjectContext sWD392_FinalProjectContext)
        {
            authorizedRoles = new string[] { Constant.PATIENT_ROLE };
            _context = sWD392_FinalProjectContext;
        }
        public async Task<IActionResult> OnGetAsync(String? id)
        {
            Account? account = HttpContext.Session.Get<Account>("loggedInAccount");

            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            //get medical record id
             _medicalRecords = _context.MedicalRecords.FirstOrDefault(p => p.PatientId.Equals(account.AccountId));
            int mdcId = _medicalRecords.MedicalRecordId;

            if (mdcId != 0 )
            {
                // Handle the case where no medical record is found for the patient
                examAt = DateTime.Parse(HttpUtility.UrlDecode(id));
                tests = new List<string>();
                var listResult = _context.ExaminationResults.Where(p => p.CreatedAt == examAt && p.MedicalRecord==mdcId).ToList();
                foreach (var record in listResult)
                {
                    PracinicalCategory serv = _context.PracinicalCategories.FirstOrDefault(p => p.PracinicalCategoryId == record.ServiceId);
                    if (serv != null)
                    {
                        tests.Add(serv.PracinicalCategoryName);
                    }
                }
            }
            return Page();
        }
    }
}
