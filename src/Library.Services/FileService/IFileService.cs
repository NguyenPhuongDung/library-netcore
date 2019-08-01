using Library.Models.Common;

namespace Library.Services.FileService
{
    public interface IFileService: IBaseService
    {
        void UploadFile(string base64, string folder, string fileName, string extension);

        void RemoveFile(string fileName, string extension, string folder);

        AttachFileModel EncodeFileToBase64Binary(AttachFileModel file);

        string ConvertToBase64(string path);

        string GetFileBase64(string folder, string fileName, string extension);
    }
}