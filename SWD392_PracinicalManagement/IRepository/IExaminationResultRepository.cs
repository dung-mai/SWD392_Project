using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.IRepository
{
    public interface IExaminationResultRepository
    {
        ExaminationResult? GetExaminationResultById(int resultId);
    }
}
