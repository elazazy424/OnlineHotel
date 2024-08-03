using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.Utility
{
    public  class ImageOperations
    {
        public ImageOperations()
        {
            
        }
        public static  UploadImage(string fileName, string folderName, string webRootPath, IFormFile file)
        {
            string uploadsFolder = Path.Combine(webRootPath, folderName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return new UploadDataCompletedEventArgs
            {
                FileName = uniqueFileName,
                FilePath = filePath
            };
        }
    }
}
