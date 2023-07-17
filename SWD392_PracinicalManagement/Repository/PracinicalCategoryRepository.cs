using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Repository
{
    public class PracinicalCategoryRepository : IPracinicalCategoryRepository
    {   
        SWD392_FinalProjectContext _context = new SWD392_FinalProjectContext();
        public void addPracinicalCategory(PracinicalCategory p)
        {
          _context.PracinicalCategories.Add(p);
          _context.SaveChanges();
        }

        public void deletePracinicalCategory(int id)
        {
            PracinicalCategory p = getPracinicalCategoryById(id);
            _context.PracinicalCategories.Remove(p);
            _context.SaveChanges();

        }

        public PracinicalCategory getPracinicalCategoryById(int id)
        {
            return _context.PracinicalCategories.Include(pc => pc.Department)
                                     .FirstOrDefault(x => x.PracinicalCategoryId == id);
        }

        public List<PracinicalCategory> getListPracinicalCategories()
        {
           return _context.PracinicalCategories.Include(pc => pc.Department)
                .Include(p => p.CreatedByNavigation).ToList();
        }

        public void updatePracinicalCategory(PracinicalCategory p)
        {
            PracinicalCategory pracinical = getPracinicalCategoryById(p.PracinicalCategoryId);
            pracinical.PracinicalCategoryName = p.PracinicalCategoryName;
            pracinical.Desctiption = p.Desctiption;
            pracinical.DepartmentId = p.DepartmentId;
            _context.SaveChanges();
        }
    }
}
