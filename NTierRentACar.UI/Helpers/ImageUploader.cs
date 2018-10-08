using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NTierRentACar.UI.Helpers
{
    public class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();

                var dosyaAdi = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "gif")
                {

                    if (File.Exists(serverPath + dosyaAdi))
                    {
                        //aynı dosya adı
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + dosyaAdi);
                        file.SaveAs(filePath);
                        return serverPath + dosyaAdi;
                    }
                }
                else
                {
                    //dosya uzantısı yanlış
                    return "2";
                }

            }
            //file parametresi null gelirse
            return "0";
        }
    }
}