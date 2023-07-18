using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages.ExaminationResult
{
    public class ExportModel : PageModelBase
    {
        private IExaminationResultService _examinationResultService;

        public ExportModel(IExaminationResultService examinationResultService)
        {
            _examinationResultService = examinationResultService;
            authorizedRoles = new string[] { Constant.DOCTOR_ROLE, Constant.MANAGER_ROLE };
        }

        //public void OnGet()
        //{
        //}

        public async Task<IActionResult> OnGet(int? resultId)
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }

            if(resultId == null || resultId == 0)
            {
                return null;
            } else
            {
                byte[] pdfData = _examinationResultService.ExportToPdf((int)resultId);
                // Trả về file PDF để người dùng tải về
                return pdfData == null ? null :  File(pdfData, "application/pdf", "Results.pdf");
            }
        }
    }
}
