namespace SWD392_PracinicalManagement.IService
{
    public interface IExaminationResultService
    {
        byte[] ExportToPdf(int resultId);
    }
}
