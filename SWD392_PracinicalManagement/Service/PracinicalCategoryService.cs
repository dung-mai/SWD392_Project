using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Repository;

namespace SWD392_PracinicalManagement.Service
{
    public class PracinicalCategoryService : IPracinicalCategoryService
    {
        IPracinicalCategoryRepository pracinicalCategoryRepository = new PracinicalCategoryRepository();
        public void addPracinicalCategory(PracinicalCategory p)
        {
            pracinicalCategoryRepository.addPracinicalCategory(p);
        }

        public void deletePracinicalCategory(int id)
        {
            pracinicalCategoryRepository.deletePracinicalCategory(id);
        }

        public List<PracinicalCategory> getListPracinicalCategories()
        {
            return pracinicalCategoryRepository.getListPracinicalCategories();
        }

        public PracinicalCategory getPracinicalCategoryById(int id)
        {
            return pracinicalCategoryRepository.getPracinicalCategoryById(id);
        }

        public void updatePracinicalCategory(PracinicalCategory p)
        {
            pracinicalCategoryRepository.updatePracinicalCategory(p);
        }
    }
}
