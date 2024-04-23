function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var ProfilePreviewCont = document.getElementById('ProfilePreviewCont');
    var Profile_Photo_Update = document.getElementById('Profile_Photo_Update');
    var submitBtn = document.getElementById('submitBtn2');

    if (input.files && input.files[0]) {
        setTimeout(function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                imagePreview.src = e.target.result;
            };
            reader.readAsDataURL(input.files[0]);
        }, 10);

    } else {
        setTimeout(function () {
            imagePreview.src = '';
        }, 10);
    }

    ProfilePreviewCont.style.transition = "0.4s ease-in-out";
    imagePreview.style.transition = "0.4s ease-in-out";
}