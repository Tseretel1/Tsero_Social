using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public interface IuploadImg
    {
        void ProfilePicUpload(ImageUpload model, string title);
        void DeleteImg(string PostPhoto);
        void UploadCover(ImageUpload model);
    }
}
