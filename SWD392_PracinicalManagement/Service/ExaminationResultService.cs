using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Util;

namespace SWD392_PracinicalManagement.Service
{
    public class ExaminationResultService : IExaminationResultService
    {
        private IExaminationResultRepository _examinationResultRepository;

        public ExaminationResultService(IExaminationResultRepository _examinationResultRepository)
        {
            this._examinationResultRepository = _examinationResultRepository;
        }

        public byte[] ExportToPdf(int resultId)
        {
            // Lấy danh sách kết quả (giả sử bạn có phương thức GetResultsAsync() để lấy dữ liệu)
            ExaminationResult? result = _examinationResultRepository.GetExaminationResultById(resultId);

            if(result == null)
            {
                return null;
            }

            // Tạo file PDF từ danh sách kết quả
            PdfService pdfService = new PdfService();
            return pdfService.CreatePdf(result);
        }
    }
}
