using System;
using System.IO;
using System.Net.Mime;

using Library.Models.Common;

using Microsoft.AspNetCore.Razor.Language;

namespace Library.Services.FileService
{
    public class FileService
    {
        public string DocumentPath { get; set; }

        // Upload file
        public void UploadFile(string base64, string folder, string fileId, string extension)
        {
            if (!string.IsNullOrEmpty(base64))
            {
                var base64Str = base64.Substring(base64.IndexOf(";base64,", StringComparison.Ordinal) + ";base64,".Length);
                var converted = base64Str.Replace('-', '+');
                converted = converted.Replace('_', '/');
                var bytes = Convert.FromBase64String(converted);

                //Validate file larger than 15MB
                //if (bytes.Length > MaximumFileMegabytes * 1024 * 1024)
                //{
                //	throw new UploadFileException("アップロードファイルはサイズ上限（" + MaximumFileMegabytes + "MB）を超えています。");
                //}

                var fullPath = DocumentPath + folder + "\\" + fileId + "." + extension;
                File.WriteAllBytes(fullPath, bytes);
            }
        }

        // Remove file
        public void RemoveFile(string fileName, string extension, string folder)
        {
            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(extension))
            {
                var fullPath = DocumentPath + folder + "\\" + fileName + "." + extension;
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }

        //public AttachFileModel EncodeFileToBase64Binary(AttachFileModel file)
        //{
        //    try
        //    {
        //        var path = DocumentPath;
        //        var extension = file.Extension.Replace(".", "");
        //        path += file.Folder + "\\" + file.FileId + "." + extension;
        //        if (File.Exists(path))
        //        {
        //            return new AttachFileModel()
        //            {
        //                FileName = file.FileName,
        //                Extension = file.Extension,
        //                Folder = file.Folder,
        //                Base64 = ConvertToBase64(path),
        //                ContentType = MimeMapping.GetMimeMapping(path),
        //            };
        //        }
        //        return null;
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return null;
        //    }
        //}

        public string ConvertToBase64(string path)
        {
            if (File.Exists(path))
            {
                var bytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(bytes);
            }
            return null;
        }

        //private static string ConvertBase64(string path)
        //{
        //    if (File.Exists(path))
        //    {
        //        var mediaType = MimeMapping.GetMimeMapping(path);
        //        var bytes = File.ReadAllBytes(path);
        //        return "data:" + mediaType + ";base64," + Convert.ToBase64String(bytes);
        //    }
        //    return null;
        //}

        //public string GetFileBase64(string folder, string fileName, string extension)
        //{
        //    try
        //    {
        //        var path = DocumentPath;
        //        if (!string.IsNullOrEmpty(extension))
        //        {
        //            extension = extension.Replace(".", "");

        //            path += folder + "\\" + fileName + "." + extension;

        //            switch (extension.ToLower())
        //            {
        //                case "png":
        //                case "jpg":
        //                case "jpeg":
        //                case "gif":
        //                case "bmp":
        //                    using (MediaTypeNames.Image image = TagHelperMetadata.Common.ReduceQualityImage(MediaTypeNames.Image.FromFile(path)))
        //                    {
        //                        using (MemoryStream m = new MemoryStream())
        //                        {
        //                            image.Save(m, ImageFormat.Jpeg);
        //                            var imageBytes = m.ToArray();

        //                            string base64String = Convert.ToBase64String(imageBytes);
        //                            image.Dispose();
        //                            return "data:image/" + extension.ToLower() + ";base64," + base64String;
        //                        }
        //                    }
        //                default:
        //                    return ConvertBase64(path);
        //            }
        //        }
        //        return null;
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return null;
        //    }
        //}
    }
}