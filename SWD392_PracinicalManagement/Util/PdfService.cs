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

                // Tạo font cho PDF
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font font = new Font(bf, 12);
                Font headerFont = new Font(bf, 16, Font.BOLD);

                // Tạo tiêu đề
                Paragraph header = new Paragraph("Examination Result", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(header);

                PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };

                // Thêm tiêu đề cho các cột
                table.AddCell("Result ID");
                table.AddCell(result.ResultId.ToString());

                table.AddCell("Medical Record");
                table.AddCell(result.MedicalRecord.ToString());

                table.AddCell("Doctor Name");
                table.AddCell(result.Doctor.Account.Name.ToString());

                table.AddCell("Service Name");
                table.AddCell(result.Service.ServiceName.ToString());

                table.AddCell("Description");
                table.AddCell(result?.Description?.ToString());

                table.AddCell("Created At");
                table.AddCell(result.CreatedAt?.ToString("yyyy-MM-dd") ?? "");

                table.AddCell("Modified At");
                table.AddCell(result.ModifiedAt?.ToString("yyyy-MM-dd") ?? "");


                // Thêm dữ liệu vào bảng


                pdfDoc.Add(table);
                pdfDoc.Close();

                return stream.ToArray();
            }
        }
    }
}
