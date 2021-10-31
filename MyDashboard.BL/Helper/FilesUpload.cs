using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Helper
{
    public static class FilesUpload
    {
        public static string UploadFiles(string FolderPath , IFormFile File)
        {
            try
            {
               
                var FilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath;

                var FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);

                var FullFilePath = Path.Combine(FilePath + FileName);

                using (var Stream = new FileStream(FilePath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }
                return FileName;
            }
            catch (Exception ex )
            {

               return ex.Message;
            }
            
        }

        public static string DeleteFiles(string FolderPath, string FileName)
        {
            try
            {

                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/"+ FolderPath + FileName))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath + FileName);
                }
                return "File Deleted";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
