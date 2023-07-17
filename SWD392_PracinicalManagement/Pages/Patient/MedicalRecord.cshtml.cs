using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.Extensions;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Util;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace SWD392_PracinicalManagement.Pages.Patient
{
    public class MedicalRecordModel : PageModelBase
    {

        SWD392_FinalProjectContext _context;
        //List<MedicalRecord> _medicalRecords;
        public Models.MedicalRecord _medicalRecords;
        public List<Models.ExaminationResult> listResult;
        public List<DateTime> dates;
        public List<string> examinations { get; set; }

        public MedicalRecordModel(SWD392_FinalProjectContext sWD392_FinalProjectContext )
        {
            authorizedRoles = new string[] { Constant.PATIENT_ROLE };
            _context = sWD392_FinalProjectContext;
        }
        public IActionResult OnGet()
        {
            Account ? account = HttpContext.Session.Get<Account>("loggedInAccount");

            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            _medicalRecords = _context.MedicalRecords.FirstOrDefault(p => p.PatientId.Equals(account.AccountId));
            if (_medicalRecords == null)
            {
                // Handle the case where no medical record is found for the patient
            }
            else
            {
                examinations = new List<string>();
                dates = new List<DateTime>();
                var listResult = _context.ExaminationResults.Where(p => p.MedicalRecord == _medicalRecords.MedicalRecordId).ToList();
                foreach (var record in listResult)
                {

                    //    DateTime date = (DateTime)record.CreatedAt;
                    //string Sdate = date.ToString("dd/MM/yyyy");

                    if (dates == null)
                    {
                        dates.Add((DateTime)record.CreatedAt);
                        //dates.Add((DateTime)record.CreatedAt);
                    }
                    else if(examinations!= null && !dates.Contains((DateTime)record.CreatedAt))
                    {
                        dates.Add((DateTime)record.CreatedAt);
                        //dates.Add((DateTime)record.CreatedAt);

                    }
                }
                //HttpContext.Session.Set<List<DateTime>>("dates", dates);

            }
            return Page();
        }
    }
}
