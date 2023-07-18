using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWD392_PracinicalManagement.Models;

namespace SWD392_PracinicalManagement.Pages.ExaminationResult
{
    public class DetailModel : PageModel
    {
        private SWD392_FinalProjectContext _context;

        
        public Models.ExaminationResult Er;
        public Models.ExaminationResult ErTmp;
        public string ErrorMessage = "";
        public DetailModel()
        {
            _context = new SWD392_FinalProjectContext();
        }
        public void OnGet(int resultId)
        {
            Er = _context.ExaminationResults.FirstOrDefault(p => p.ResultId == resultId);
            if (Er == null)
            {
                ErrorMessage = "Error";
            }
        }

        public  async void OnPostImportFile(int resultID, IFormFile AttachmentFile)
        {
            if (AttachmentFile != null && AttachmentFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await AttachmentFile.CopyToAsync(memoryStream);

                    // Get the array of bytes from the MemoryStream
                    byte[] fileBytes = memoryStream.ToArray();

                    // Now you can save fileBytes to your database
                    Models.ExaminationResult examResult = _context.ExaminationResults.FirstOrDefault(p => p.ResultId == resultID);
                    examResult.AttachmentFile = fileBytes;
                    _context.SaveChanges();
                }
            }
        }
    }
}
