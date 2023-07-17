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
        IExaminationFormService service = new ExaminationFormService();
        public List<ExaminationForm> examFormList;

        public ExaminationFormListModel( )
        {    
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

        private void LoadData()
        {
            examFormList = service.GetExaminationForms();
        }
    }
}
