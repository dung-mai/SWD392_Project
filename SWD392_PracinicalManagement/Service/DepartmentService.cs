using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Repository;

namespace SWD392_PracinicalManagement.Service
{
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentRepository departmentRepository = new DepartmentRepository();
        public List<Department> getListDepartment()
        {
            return departmentRepository.getListDepartMent();
        }
    }
}
