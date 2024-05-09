using Tsero_Social.Models;

namespace Tsero_Social.InterFaces
{
    public interface IuploadImg
    {
        void ProfilePicUpload(ImageUpload model, string title);
        void DeleteImg(string PostPhoto);
        void UploadCover(ImageUpload model);
    }
}
