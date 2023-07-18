using iTextSharp.text;
using iTextSharp.text.pdf;
using SWD392_PracinicalManagement.Models;
using System.Collections.Generic;
using System.IO;

namespace SWD392_PracinicalManagement.Util
{
    public class PdfService
    {
        public byte[] CreatePdf(ExaminationResult result)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Tạo một tài liệu PDF mới
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);

                // Mở tài liệu và thêm nội dung
                pdfDoc.Open();
                PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };

                // Thêm tiêu đề cho các cột
                table.AddCell("Result ID");
                table.AddCell("Medical Record");
                table.AddCell("Doctor ID");
                table.AddCell("Service ID");
                table.AddCell("Created At");
                table.AddCell("Modified At");

                // Thêm dữ liệu vào bảng
                table.AddCell(result.ResultId.ToString());
                table.AddCell(result.MedicalRecord.ToString());
                table.AddCell(result.DoctorId.ToString());
                table.AddCell(result.ServiceId.ToString());
                table.AddCell(result.CreatedAt?.ToString("yyyy-MM-dd") ?? "");
                table.AddCell(result.ModifiedAt?.ToString("yyyy-MM-dd") ?? "");


                pdfDoc.Add(table);
                pdfDoc.Close();

                return stream.ToArray();
            }
        }
    }
}
