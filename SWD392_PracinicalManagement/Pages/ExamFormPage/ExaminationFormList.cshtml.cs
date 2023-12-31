using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Service;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages.ExamFormPage
{
    public class ExaminationFormListModel : PageModelBase
    {
        IExaminationFormService service;
        public List<ExaminationForm> examFormList;

        public ExaminationFormListModel(IExaminationFormService service)
        {
            this.service = service;
            authorizedRoles = new string[] { "manager", "doctor" };
        }

        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            LoadData();
            return Page();
        }

        public void OnPostFilterDoctor(int? doctor)
        {
            examFormList = service.GetExaminationFormByDoctorId((int)doctor);
        }

        public void OnPostFilterPatient(int? patient)
        {
            examFormList = service.GetExaminationFormByPatientId((int)patient);
        }

        public void OnPostFilterDate(DateTime? date)
        {
            examFormList = service.GetExaminationFormByDate((DateTime)date);
        }

        private void LoadData()
        {
            examFormList = service.GetExaminationForms();
        }
    }
}
