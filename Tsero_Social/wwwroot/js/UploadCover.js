function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var ProfilePreviewCont = document.getElementById('ProfilePreviewCont');
    var EditProfileContainer2 = document.getElementById('EditProfileContainer2');
    var Editbutton = document.getElementById('EditButton');

    if (input.files && input.files[0]) {
        setTimeout(function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                EditProfileContainer2.style.background = "url(" + e.target.result + ")";
            };
            reader.readAsDataURL(input.files[0]);
            Editbutton.style.display = "flex";
        }, 10);

    } else {
        setTimeout(function () {
            imagePreview.src = '';
            Editbutton.style.display = "none";
        }, 10);
    }

    ProfilePreviewCont.style.transition = "0.4s ease-in-out";
    imagePreview.style.transition = "0.4s ease-in-out";
}
