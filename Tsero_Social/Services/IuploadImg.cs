﻿using Tsero_Social.Models;

namespace Tsero_Social.Services
{
    public interface IuploadImg
    {
        void ProfilePicUpload(ImageUpload model, string title);
    }
}
