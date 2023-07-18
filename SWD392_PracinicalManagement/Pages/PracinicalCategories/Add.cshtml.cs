using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Service;
using SWD392_PracinicalManagement.Util;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SWD392_PracinicalManagement.Pages.PracinicalCategories
{
    public class AddModel : PageModelBase
    {   
        public AddModel()
        {
            authorizedRoles = new string[] {Constant.MANAGER_ROLE};
        }

        public IPracinicalCategoryService pService = new PracinicalCategoryService();

        public IDepartmentService dService = new DepartmentService();
        public List<Department> departments { get; set; }

        public List<PracinicalCategory> pracinicalCategories { get; set; }
        public IActionResult OnGet()
        {
            if(!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            getData();
            return Page();
        }

        public void getData()
        {
            departments = dService.getListDepartment();
            pracinicalCategories = pService.getListPracinicalCategories();
        }    

        public IActionResult OnPost()
        {
           var pracinicalCategoryName = Request.Form["pracinicalCategoryName"];
           var departmentId = Request.Form["department"];
           var description = Request.Form["description"];
            if(Validation(pracinicalCategoryName))
            {
                PracinicalCategory p = new PracinicalCategory();
                p.PracinicalCategoryName = pracinicalCategoryName;
                p.DepartmentId = Int32.Parse(departmentId);
                p.Desctiption = description;
                p.CreatedBy = /*LoggedInAccount.AccountId*/6;
                p.CreatedDate = DateTime.Now;
                pService.addPracinicalCategory(p);
                string message = "Thêm danh mục khám cận lâm sàng thành công.";
                TempData["message"] = message;
            }
            else
            {
                string messageError = "Tên danh mục chứa ký tự đặc biệt";
                TempData["error-message"] = messageError;
            }
            
            getData();
            return Page();
        }

        public IActionResult OnPostImportFile()
        {
            var file = Request.Form.Files["file"];
            if (file != null && file.Length > 0)
            {
                using (TextFieldParser parser = new TextFieldParser(file.OpenReadStream()))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        // Processing row
                        string[] fields = parser.ReadFields();
                        PracinicalCategory pracinicalCategory = new PracinicalCategory()
                        {
                            PracinicalCategoryName = fields[0],
                            Desctiption = fields[1],
                            DepartmentId = Int32.Parse(fields[2]),
                            CreatedBy = Int32.Parse(fields[3]),
                            CreatedDate = DateTime.Now,
                        };
                        pService.addPracinicalCategory(pracinicalCategory);
                    }
                }
            }
            getData();
            return Page();
        }

        private bool Validation(String name)
        {
            string specialCharactersPattern = @"[^a-zA-Z0-9_ ]";
            if (Regex.IsMatch(name, specialCharactersPattern))
            {
                return false;
            }
            return true;
        }
    }
}
