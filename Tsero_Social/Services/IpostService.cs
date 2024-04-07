using Tsero_Social.Migrations;
using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public interface IpostService
    {
        void PostWriting(string PostTitle, string PostPost, ImageUpload model);
        void Myposts ();
    }
}
