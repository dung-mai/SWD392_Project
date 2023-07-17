using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Service;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages.PracinicalCategories
{
    public class DeleteModel : PageModelBase
    {
        public DeleteModel()
        {
            authorizedRoles = new string[] { Constant.MANAGER_ROLE };
        }

        public IPracinicalCategoryService pService = new PracinicalCategoryService();
        public IActionResult OnGet(int id)
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            if (id != null)
            {
                pService.deletePracinicalCategory(id);
            }
                return Redirect("/PracinicalCategories/Add");
        }
    }
}
