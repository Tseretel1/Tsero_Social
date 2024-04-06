using Tsero_Social.Migrations;

namespace Tsero_Social.Services
{
    public interface IpostService
    {
        void PostWriting (posts posts);
        void Myposts (posts posts);
    }
}
