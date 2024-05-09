using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.InterFaces
{
    public interface IpostService
    {
        void PostWriting(string PostPost, ImageUpload model);
        void DeletePost(int id, string PostPhoto);
    }
}
