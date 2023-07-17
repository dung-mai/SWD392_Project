using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Service;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Pages.PracinicalCategories
{
    public class UpdateModel : PageModelBase
    {   
        public UpdateModel()
        {
            authorizedRoles = new string[] { Constant.MANAGER_ROLE };
        }

        public PracinicalCategory pracinicalCategory { get; set; }

        public List<Department> departments { get; set; }

        public IDepartmentService dService = new DepartmentService();

        public IPracinicalCategoryService pService = new PracinicalCategoryService();
        public IActionResult OnGet(int id)
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            if(id != null)
            {
                pracinicalCategory = pService.getPracinicalCategoryById(id);
                departments = dService.getListDepartment();
            }
            else
            {
                return Redirect("/PracinicalCategories/Add");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var Id = Request.Form["id"];
            var pracinicalCategoryName = Request.Form["pracinicalCategoryName"];
            var departmentId = Request.Form["department"];
            var description = Request.Form["description"];

            PracinicalCategory p = new PracinicalCategory();
            p.PracinicalCategoryId = Int32.Parse(Id);
            p.PracinicalCategoryName = pracinicalCategoryName;
            p.DepartmentId = Int32.Parse(departmentId);
            p.Desctiption = description;
            pService.updatePracinicalCategory(p);
            return Redirect("/PracinicalCategories/Add");
        }
    }
}
