using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IService
{
    public interface IPracinicalCategoryService
    {
        List<PracinicalCategory> getListPracinicalCategories();

        PracinicalCategory getPracinicalCategoryById(int id);

        void addPracinicalCategory(PracinicalCategory p);

        void updatePracinicalCategory(PracinicalCategory p);

        void deletePracinicalCategory(int id);
    }
}
