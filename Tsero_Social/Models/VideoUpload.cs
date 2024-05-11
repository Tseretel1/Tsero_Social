using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class VideoUpload
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public string PathToDisplay { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile VideoFile { get; set; }
    }
}
