using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SWD392_FinalProjectContext _context = new SWD392_FinalProjectContext();
        public List<Department> getListDepartMent()
        {
            return _context.Departments.ToList();
        }

    }
}
