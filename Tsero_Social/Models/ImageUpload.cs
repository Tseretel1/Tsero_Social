using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsero_Social.Models
{
    public class ImageUpload
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int Userid { get; set; }
        public string PathToDisplay { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
     }
}
